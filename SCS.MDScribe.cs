using System.Text;

namespace SCS.MDScribe;

public class MDScribeBuilder
{
    private readonly StringBuilder _sb = new StringBuilder();

    private static string CleanHeader(string text)
    {
        return text.Replace("\r", "").Replace("\n", " ").Trim();
    }

    public override string ToString() => _sb.ToString();

    public MDScribeBuilder AppendRaw(string text)
    {
        _sb.Append(text);
        return this;
    }

    public MDScribeBuilder AppendLine(string text = "")
    {
        _sb.AppendLine(text);
        return this;
    }

    // Headers
    public MDScribeBuilder H1(string text)
    {
        _sb.AppendLine("# " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder H2(string text)
    {
        _sb.AppendLine("## " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder H3(string text)
    {
        _sb.AppendLine("### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder H4(string text)
    {
        _sb.AppendLine("#### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder H5(string text)
    {
        _sb.AppendLine("##### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder H6(string text)
    {
        _sb.AppendLine("###### " + CleanHeader(text));
        _sb.AppendLine();
        return this;
    }

    // Text Blocks
    public MDScribeBuilder Paragraph(string text)
    {
        _sb.AppendLine(text.Trim());
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder BlockQuote(string text)
    {
        foreach (var line in text.Split('\n'))
            _sb.AppendLine("> " + line.TrimEnd());
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder HorizontalRule()
    {
        _sb.AppendLine("---");
        _sb.AppendLine();
        return this;
    }

    // Inline formatting
    public MDScribeBuilder Bold(string text)
    {
        _sb.Append("**" + text + "**");
        return this;
    }

    public MDScribeBuilder Italic(string text)
    {
        _sb.Append("*" + text + "*");
        return this;
    }

    public MDScribeBuilder Strike(string text)
    {
        _sb.Append("~~" + text + "~~");
        return this;
    }

    public MDScribeBuilder InlineCode(string text)
    {
        _sb.Append("`" + text + "`");
        return this;
    }

    // Lists
    public MDScribeBuilder BulletList(IEnumerable<string> items)
    {
        foreach (var item in items)
            _sb.AppendLine("- " + item.Trim());
        _sb.AppendLine();
        return this;
    }

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

    // Code Blocks
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

    // Media
    public MDScribeBuilder Image(string alt, string url)
    {
        _sb.AppendLine("![" + alt + "](" + url + ")");
        _sb.AppendLine();
        return this;
    }

    public MDScribeBuilder Link(string text, string url)
    {
        _sb.Append("[" + text + "](" + url + ")");
        return this;
    }

    // Tables
    public MDScribeBuilder Table(string[] headers, IEnumerable<string[]> rows)
    {
        _sb.AppendLine(string.Join(" | ", headers));
        _sb.AppendLine(string.Join(" | ", headers.Select(_ => "---")));

        foreach (var row in rows)
            _sb.AppendLine(string.Join(" | ", row));

        _sb.AppendLine();
        return this;
    }
}
