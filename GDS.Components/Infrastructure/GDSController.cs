namespace GDS.Components.Infrastructure
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Models;
    using GDS.Components.Validators;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.ComponentModel.DataAnnotations;

    public class GDSController : Controller
    {
        public void ValidateModel<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null");
            }

            ModelState.Clear();
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            Validator.TryValidateObject(model, validationContext, validationResults, true);

            foreach (var property in typeof(T).GetProperties())
            {
                var propertyValue = property.GetValue(model);
                var propertyContext = new ValidationContext(model) { MemberName = property.Name };
                Validator.TryValidateProperty(propertyValue, propertyContext, validationResults);
            }
            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    if (ModelState.ContainsKey(memberName))
                    {
                        ModelState[memberName].Errors.Clear();
                        ModelState[memberName].Errors.Add(new ModelError(validationResult.ErrorMessage));
                    }
                    else
                    {
                        ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                    }

                    if (memberName.EndsWith(".Value") || memberName.EndsWith(".SelectedValue"))
                    {
                        var propertyName = memberName.Split('.')[0];
                        var property = typeof(T).GetProperty(propertyName);

                        if (property != null)
                        {
                            var propertyValue = property.GetValue(model);
                            if (propertyValue != null)
                            {
                                var errorProperty = propertyValue.GetType().GetProperty("Error");
                                if (errorProperty != null)
                                {
                                    errorProperty.SetValue(propertyValue, validationResult.ErrorMessage);
                                }
                                if (validationResult is CustomDateValidationResult customValidationResult)
                                {
                                    var errorTypeProperty = propertyValue.GetType().GetProperty("ErrorType");
                                    if (errorTypeProperty != null && errorTypeProperty.PropertyType == typeof(DateInputErrorType))
                                    {
                                        errorTypeProperty.SetValue(propertyValue, customValidationResult.ErrorType);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public IList<BaseUrlModel> MapErrors<T>()
        {
            var ErrorList = new List<BaseUrlModel>();
            var properties = typeof(T).GetProperties();

            foreach (var error in ModelState)
            {
                var controlId = error.Key.Split(".")[0].ToLower();
                var property = properties.FirstOrDefault(p => p.Name.ToLower() == controlId);

                if (property != null && Attribute.IsDefined(property, typeof(ListControlAttribute)))
                {
                    controlId = $"{controlId}-0";
                }

                ErrorList.Add(new BaseUrlModel
                {
                    Text = error.Value.Errors[0].ErrorMessage,
                    Url = $"#{controlId}"
                });
            }

            return ErrorList;
        }
    }
}
