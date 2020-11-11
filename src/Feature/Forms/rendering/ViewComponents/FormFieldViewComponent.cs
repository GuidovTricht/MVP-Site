using Microsoft.AspNetCore.Mvc;
using Mvp.Feature.Forms.Models;

namespace Mvp.Feature.Forms.ViewComponents
{
    [ViewComponent(Name = "FormField")]
    public class FormFieldViewComponent : ViewComponent
    {
        public FormFieldViewComponent()
        {

        }
        public IViewComponentResult Invoke(FormField field)
        {
            if (Constants.FieldTypes.TryGetValue(field.Model.FieldTypeItemId, out FormFieldTypes fieldTypes)){
                var viewName = fieldTypes.ToString();

                return View(viewName, field);
            }
            return View(field);
        }
    }
}
