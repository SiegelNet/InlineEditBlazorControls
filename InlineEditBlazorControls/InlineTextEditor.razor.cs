using Microsoft.AspNetCore.Components;
using System;

namespace InlineEditBlazorControls
{
    public partial class InlineTextEditor : ComponentBase
    {
        public bool EditMode { get; set; } = false;

        [Parameter]
        public EventCallback<InlineEditTextCallback> ValueSaved { get; set; }


        [Parameter]
        public string EditableValue { get; set; } = "";

        [Parameter]
        public int EditableValueId { get; set; }

        void ActivateEditMode()
        {
            EditMode = true;
        }

        void SaveValue()
        {
            ValueSaved.InvokeAsync(new InlineEditTextCallback(EditableValue, EditableValueId));
            EditMode = false;
        }

        void CancelEditMode()
        {
            EditMode = false;
        }
    }

    public record InlineEditTextCallback
    {
        public int? ReferenceId { get; set; }
        public string Value { get; set; }

        public InlineEditTextCallback(string value) => (Value) = (value);
        public InlineEditTextCallback(string value, int referenceId) => (Value, ReferenceId) = (value, referenceId);
    }
}
