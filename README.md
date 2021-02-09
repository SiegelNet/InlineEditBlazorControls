# InlineEditBlazorControls
In-place editing controls for Blazor - inspired from X-editable

## Text Edit

```html
<InlineTextEditor EditableValue="@match.Comment" EditableValueId="@match.MatchId" ValueSaved="CommentEdited"></InlineTextEditor>

@code {
    void CommentEdited(InlineEditTextCallback e)
    {
        Matches.Where(m => m.MatchId == e.ReferenceId).FirstOrDefault().Comment = e.Value;

        // do something else, save in DB, ...
    }
}
```




![Textedit](.github/images/textedit.png)
