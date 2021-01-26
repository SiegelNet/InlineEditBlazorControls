using Microsoft.AspNetCore.Components;
using System;

namespace InlineEditBlazorControls
{
    public partial class InlineTextEditor : ComponentBase
    {
        public bool EditMode { get; set; } = false;

        [Parameter]
        public EventCallback<Tuple<string, int?>> ValueSaved { get; set; }

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
            ValueSaved.InvokeAsync(new Tuple<string, int?>(EditableValue, EditableValueId));
            EditMode = false;
        }

        void CancelEditMode()
        {
            EditMode = false;
        }
    }
}
