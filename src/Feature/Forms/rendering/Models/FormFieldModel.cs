using System;
using System.Collections.Generic;

namespace Mvp.Feature.Forms.Models
{
    public class FormFieldModel
    {
        //Input fields
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string PlaceholderText { get; set; }
        public string Value { get; set; }
        public List<FormValidationDataModel> ValidationDataModels { get; set; }
        public FormValueProviderSettings ValueProviderSettings { get; set; }
        public bool IsTrackingEnabled { get; set; }
        public bool Required { get; set; }
        public bool AllowSave { get; set; }
        
        //Submit button
        public int NavigationStep { get; set; }
        public List<FormSubmitAction> SubmitActions { get; set; }

        //All
        public string Title { get; set; }
        public string LabelCssClass { get; set; }
        public FormConditionSettings ConditionSettings { get; set; }
        public string CssClass { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public Guid TemplateId { get; set; }
        public Guid FieldTypeItemId { get; set; }
    }
}
