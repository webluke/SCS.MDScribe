# MDScribe by Sweet Corn Software

MDScribe is a fluent, developer‑friendly Markdown builder for .NET.  
It makes it easy to generate structured Markdown documents using a clean, chainable API instead of string concatenation.

Designed for C#, Blazor, ASP.NET, API output, tools, documentation generators, and any workflow where you need clean Markdown output.

---

## Features

- Fluent Markdown building API
- Automatic header cleanup (no newline issues)
- Paragraphs, inline formatting, links, images
- Bullet, numbered, and task lists
- Code blocks with optional language hinting
- Tables with headers and rows
- Blockquotes, horizontal rules, raw text support
- Zero external dependencies
- Output is plain Markdown text

---

## Installation

```bash
dotnet add package SCS.MDScribe
```

---

## Quick Example

```csharp
var md = new MDScribeBuilder()
    .H1("My Document")
    .Paragraph("Generated using MDScribe.")
    .H2("Features")
    .BulletList(new [] { "Simple", "Fast", "Fluent" })
    .CodeBlock("Console.WriteLine(\"Hello\");", "csharp")
    .ToString();

File.WriteAllText("output.md", md);
```

---

## Why MDScribe?

- Cleaner than manual string templates
- More predictable than regex‑based generators
- Perfect for dynamic content generation (reports, exports, blog tooling, AI output formatting, CMS pipelines)
- Small, fast, and dependency‑free

---

## API Overview

### Headers

```csharp
.H1("Title")
.H2("Section")
.H3("Subsection")
```

### Headings With Anchors

```csharp
.H2WithAnchor("API Reference", "api-ref");
```


### Text Blocks

```csharp
.Paragraph("Text")
.BlockQuote("Quote text")
.HorizontalRule()
```

### Inline Formatting

```csharp
.Bold("text")
.Italic("text")
.Strike("text")
.InlineCode("value")
```

### Highlight Text

```csharp
.Paragraph("This is ").Highlight("important").AppendLine(".");
```

### Emoji

```csharp
.Paragraph("Build successful ").Emoji("sparkles");
```

### Lists

```csharp
.BulletList(new[] { "A", "B" })
.NumberList(new[] { "Step 1", "Step 2" })
.TaskList(new [] { ("Do work", false), ("Ship", true) })
.DefinitionList("API", "Application Programming Interface");
```

### Code Blocks

```csharp
.CodeBlock("Console.WriteLine(\"Hello\");", "csharp")
```

### Tables

```csharp
.Table(
    new[] { "Name", "Value" },
    new[] {
        new[] { "CPU", "Intel" },
        new[] { "RAM", "16GB" }
    }
)
```

### Table With Alignment

```csharp
.TableWithAlignment(
    new[] { "Name", "Score", "Status" },
    new[] { "left", "center", "right" },
    new[]
    {
        new[] { "Alice", "92", "Pass" },
        new[] { "Bob", "76", "Pass" },
        new[] { "Charlie", "48", "Fail" }
    }
);
```


### Footnotes

```csharp
.Paragraph("This is text with a footnote")
.FootnoteReference("1")
.FootnoteDefinition("1", "This is the footnote.");
```

### Math Blocks

```csharp
.MathBlock(@"x = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a}");
```

### Collapsible Sections

```csharp
.Collapsible("Show Details", "Here are more details inside a collapsible section.");
```


### Callouts

```csharp
.Note("This method is experimental.");
.Tip("Use MDScribe to generate clean markdown.");
.Warning("Do not forget to escape user input.");
```

---

## License

MIT License.  
You are free to use, modify, and distribute MDScribe.

---

## Credits

MDScribe is developed by WebLuke of [Sweet Corn Software](https://www.sweetcornsoftware.com).  
Assisted by **T3 Chat (GPT‑5.1 Instant)**.
