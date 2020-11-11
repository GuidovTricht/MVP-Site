namespace Mvp.Feature.Forms.Models
{
    public class FormField
    {
        //Input fields
        public FormProperty IndexField { get; set; }
        public FormProperty FieldIdField { get; set; }
        public FormProperty ValueField { get; set; }

        //Submit button
        public FormProperty NavigationButtonsField { get; set; }
        public FormProperty NavigationStepField { get; set; }
        public FormProperty ButtonField { get; set; }

        //All
        public FormFieldModel Model { get; set; }
    }
}
