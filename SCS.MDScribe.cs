using System.Text;

namespace SCS.MDScribe;

/// <summary>
/// Provides a fluent API for generating Markdown documents programmatically.
/// </summary>
public class MDScribeBuilder
{
    private readonly StringBuilder _sb = new StringBuilder();

    private static string CleanHeader(string text)
    {
        return text.Replace("\r", "").Replace("\n", " ").Trim();
    }

    /// <summary>
    /// Returns the complete Markdown output built so far.
    /// </summary>
    /// <returns>A string containing the generated Markdown.</returns>
    public override string ToString() => _sb.ToString();

    /// <summary>
    /// Appends raw, unmodified text directly to the output.
    /// </summary>
    /// <param name="text">The raw text to append.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder AppendRaw(string text)
    {
        _sb.Append(text);
        return this;
    }

    /// <summary>
    /// Appends a line of text followed by a newline.
    /// </summary>
    /// <param name="text">The line to append. If omitted, only a newline is added.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder AppendLine(string text = "")
    {
        _sb.AppendLine(text);
        return this;
    }

    // Headers ---------------------------------------------------------------

    /// <summary>
    /// Appends an H1 header.
    /// </summary>
    /// <param name="text">The header text. Newlines are removed automatically.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder H1(string text)
    {
        _sb.AppendLine("# " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends an H2 header.
    /// </summary>
    /// <param name="text">The header text. Newlines are removed automatically.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder H2(string text)
    {
        _sb.AppendLine("## " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends an H3 header.
    /// </summary>
    /// <param name="text">The header text. Newlines are removed automatically.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder H3(string text)
    {
        _sb.AppendLine("### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends an H4 header.
    /// </summary>
    public MDScribeBuilder H4(string text)
    {
        _sb.AppendLine("#### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends an H5 header.
    /// </summary>
    public MDScribeBuilder H5(string text)
    {
        _sb.AppendLine("##### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends an H6 header.
    /// </summary>
    public MDScribeBuilder H6(string text)
    {
        _sb.AppendLine("###### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    // Text Blocks -----------------------------------------------------------

    /// <summary>
    /// Appends a paragraph.
    /// </summary>
    /// <param name="text">The paragraph text. Surrounding whitespace is trimmed.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder Paragraph(string text)
    {
        _sb.AppendLine(text.Trim());
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a blockquote section.
    /// </summary>
    /// <param name="text">The text to format as a blockquote. Multi-line text is supported.</param>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder BlockQuote(string text)
    {
        foreach (var line in text.Split('\n'))
            _sb.AppendLine("> " + line.TrimEnd());
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a horizontal rule.
    /// </summary>
    /// <returns>The current builder instance.</returns>
    public MDScribeBuilder HorizontalRule()
    {
        _sb.AppendLine("---");
        _sb.AppendLine();
        return this;
    }

    // Inline Formatting -----------------------------------------------------

    /// <summary>
    /// Appends bold text.
    /// </summary>
    /// <param name="text">The text to make bold.</param>
    public MDScribeBuilder Bold(string text)
    {
        _sb.Append("**" + text + "**");
        return this;
    }

    /// <summary>
    /// Appends italic text.
    /// </summary>
    /// <param name="text">The text to italicize.</param>
    public MDScribeBuilder Italic(string text)
    {
        _sb.Append("*" + text + "*");
        return this;
    }

    /// <summary>
    /// Appends strikethrough text.
    /// </summary>
    /// <param name="text">The text to strike through.</param>
    public MDScribeBuilder Strike(string text)
    {
        _sb.Append("~~" + text + "~~");
        return this;
    }

    /// <summary>
    /// Appends inline code.
    /// </summary>
    /// <param name="text">The inline code content.</param>
    public MDScribeBuilder InlineCode(string text)
    {
        _sb.Append("`" + text + "`");
        return this;
    }

    // Lists -----------------------------------------------------------------

    /// <summary>
    /// Appends a bullet list.
    /// </summary>
    /// <param name="items">The items to include in the list.</param>
    public MDScribeBuilder BulletList(IEnumerable<string> items)
    {
        foreach (var item in items)
            _sb.AppendLine("- " + item.Trim());
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a numbered list.
    /// </summary>
    /// <param name="items">The ordered list items.</param>
    public MDScribeBuilder NumberList(IEnumerable<string> items)
    {
        int i = 1;
        foreach (var item in items)
        {
            _sb.AppendLine(i.ToString() + ". " + item.Trim());
            i++;
        }
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a task list where each item includes a checkbox.
    /// </summary>
    /// <param name="items">A collection of text and completion state pairs.</param>
    public MDScribeBuilder TaskList(IEnumerable<(string text, bool done)> items)
    {
        foreach (var item in items)
        {
            var mark = item.done ? "x" : " ";
            _sb.AppendLine("- [" + mark + "] " + item.text.Trim());
        }
        _sb.AppendLine();
        return this;
    }

    // Code Blocks -----------------------------------------------------------

    /// <summary>
    /// Appends a fenced code block.
    /// </summary>
    /// <param name="code">The code content.</param>
    /// <param name="language">Optional language identifier for syntax highlighting.</param>
    public MDScribeBuilder CodeBlock(string code, string language = "")
    {
        if (!string.IsNullOrWhiteSpace(language))
            _sb.AppendLine("```" + language);
        else
            _sb.AppendLine("```");

        _sb.AppendLine(code);
        _sb.AppendLine("```");
        _sb.AppendLine();
        return this;
    }

    // Media -----------------------------------------------------------------

    /// <summary>
    /// Appends an image reference.
    /// </summary>
    /// <param name="alt">The alt text.</param>
    /// <param name="url">The image URL.</param>
    public MDScribeBuilder Image(string alt, string url)
    {
        _sb.AppendLine("![" + alt + "](" + url + ")");
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a hyperlink.
    /// </summary>
    public MDScribeBuilder Link(string text, string url)
    {
        _sb.Append("[" + text + "](" + url + ")");
        return this;
    }

    // Tables ----------------------------------------------------------------

    /// <summary>
    /// Appends a basic Markdown table.
    /// </summary>
    /// <param name="headers">Column headers.</param>
    /// <param name="rows">Row values.</param>
    public MDScribeBuilder Table(string[] headers, IEnumerable<string[]> rows)
    {
        _sb.AppendLine(string.Join(" | ", headers));
        _sb.AppendLine(string.Join(" | ", headers.Select(_ => "---")));

        foreach (var row in rows)
            _sb.AppendLine(string.Join(" | ", row));

        _sb.AppendLine();
        return this;
    }

    // Footnotes -------------------------------------------------------------

    /// <summary>
    /// Inserts a footnote reference.
    /// </summary>
    /// <param name="id">The footnote ID.</param>
    public MDScribeBuilder FootnoteReference(string id)
    {
        _sb.Append("[^" + id + "]");
        return this;
    }

    /// <summary>
    /// Defines a footnote.
    /// </summary>
    /// <param name="id">Footnote ID that matches a reference.</param>
    /// <param name="text">The footnote text.</param>
    public MDScribeBuilder FootnoteDefinition(string id, string text)
    {
        _sb.AppendLine("[^" + id + "]: " + text);
        _sb.AppendLine();
        return this;
    }

    // Definition List -------------------------------------------------------

    /// <summary>
    /// Appends a definition term and description pair.
    /// </summary>
    /// <param name="term">The term being defined.</param>
    /// <param name="definition">The associated definition.</param>
    public MDScribeBuilder DefinitionList(string term, string definition)
    {
        _sb.AppendLine(term);
        _sb.AppendLine(": " + definition);
        _sb.AppendLine();
        return this;
    }

    // Anchored Header -------------------------------------------------------

    /// <summary>
    /// Appends an H2 header with an HTML anchor name.
    /// </summary>
    /// <param name="text">Header text.</param>
    /// <param name="anchor">The anchor name used for linking.</param>
    public MDScribeBuilder H2WithAnchor(string text, string anchor)
    {
        _sb.AppendLine("## " + CleanHeader(text) + " <a name=\"" + anchor + "\"></a>");
        _sb.AppendLine();
        return this;
    }

    // Math ------------------------------------------------------------------

    /// <summary>
    /// Appends a fenced math block using math code fences.
    /// </summary>
    /// <param name="math">The math expression.</param>
    public MDScribeBuilder MathBlock(string math)
    {
        _sb.AppendLine("```math");
        _sb.AppendLine(math);
        _sb.AppendLine("```");
        _sb.AppendLine();
        return this;
    }

    // Highlight -------------------------------------------------------------

    /// <summary>
    /// Appends highlighted text using the ==text== syntax.
    /// </summary>
    /// <param name="text">The text to highlight.</param>
    public MDScribeBuilder Highlight(string text)
    {
        _sb.Append("==" + text + "==");
        return this;
    }

    // Emoji -----------------------------------------------------------------

    /// <summary>
    /// Appends a text-based emoji shortcode.
    /// </summary>
    /// <param name="shortcode">The emoji shortcode, such as sparkles or smile.</param>
    public MDScribeBuilder Emoji(string shortcode)
    {
        _sb.Append(":" + shortcode + ":");
        return this;
    }

    // Collapsible -----------------------------------------------------------

    /// <summary>
    /// Appends a collapsible section using GitHub flavored Markdown.
    /// </summary>
    /// <param name="summary">The text that appears in the collapsed summary line.</param>
    /// <param name="content">The content displayed when expanded.</param>
    public MDScribeBuilder Collapsible(string summary, string content)
    {
        _sb.AppendLine("<details>");
        _sb.AppendLine("<summary>" + summary + "</summary>");
        _sb.AppendLine();
        _sb.AppendLine(content);
        _sb.AppendLine();
        _sb.AppendLine("</details>");
        _sb.AppendLine();
        return this;
    }

    // Table With Alignment --------------------------------------------------

    /// <summary>
    /// Appends a Markdown table with per-column alignment settings.
    /// </summary>
    /// <param name="headers">The column headers.</param>
    /// <param name="alignment">Column alignment options: left, center, right.</param>
    /// <param name="rows">The table rows.</param>
    public MDScribeBuilder TableWithAlignment(string[] headers, string[] alignment, IEnumerable<string[]> rows)
    {
        _sb.AppendLine(string.Join(" | ", headers));
        _sb.AppendLine(string.Join(" | ", alignment.Select(a => a.ToLower() switch
        {
            "left" => ":---",
            "center" => ":---:",
            "right" => "---:",
            _ => "---"
        })));

        foreach (var row in rows)
            _sb.AppendLine(string.Join(" | ", row));

        _sb.AppendLine();
        return this;
    }

    // Callouts --------------------------------------------------------------

    /// <summary>
    /// Appends a note callout block.
    /// </summary>
    /// <param name="text">The message shown inside the callout.</param>
    public MDScribeBuilder Note(string text)
    {
        _sb.AppendLine("> **Note:** " + text);
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a tip callout block.
    /// </summary>
    /// <param name="text">The message shown inside the callout.</param>
    public MDScribeBuilder Tip(string text)
    {
        _sb.AppendLine("> **Tip:** " + text);
        _sb.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a warning callout block.
    /// </summary>
    /// <param name="text">The message shown inside the callout.</param>
    public MDScribeBuilder Warning(string text)
    {
        _sb.AppendLine("> **Warning:** " + text);
        _sb.AppendLine();
        return this;
    }
}