using System;

namespace Mvp.Feature.Forms.Models
{
    public class FormSubmitAction
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public Guid SubmitActionId { get; set; }
        public string Parameters { get; set; }
        public string Description { get; set; }
    }
}
