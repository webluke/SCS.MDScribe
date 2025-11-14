# MDScribe by Sweet Corn Software

MDScribe is a fluent, developer‑friendly Markdown builder for .NET.  
It makes it easy to generate structured Markdown documents using a clean, chainable API instead of string concatenation.

Designed for C#, Blazor, ASP.NET, API output, tools, documentation generators, and any workflow where you need clean Markdown output.

*Built with help from T3 Chat (GPT‑5.1 Instant), guided by Luke.*

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
dotnet add package MDScribe
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

### Lists

```csharp
.BulletList(new[] { "A", "B" })
.NumberList(new[] { "Step 1", "Step 2" })
.TaskList(new [] { ("Do work", false), ("Ship", true) })
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

---

## License

MIT License.  
You are free to use, modify, and distribute MDScribe.

---

## Credits

MDScribe is developed by WebLuke of [Sweet Corn Software](https://www.sweetcornsoftware.com).  
Assisted by **T3 Chat (GPT‑5.1 Instant)**.
