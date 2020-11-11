using System;

namespace Mvp.Feature.Forms.Models
{
    public class FormValidationDataModel
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ModelType { get; set; }
        public string Message { get; set; }
        public string Parameters { get; set; }
    }
}
