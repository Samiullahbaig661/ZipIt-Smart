# Contributing to ZipITSmart 🤝

Thank you for your interest in contributing to **ZipITSmart**!
We welcome contributions that improve functionality, performance, UI/UX, documentation, or overall code quality.

This document outlines the guidelines to help you contribute effectively and consistently.

---

## 📌 Project Overview

**ZipITSmart** is a Windows Forms–based compression and decompression tool written in **C# (.NET 10)** using **Huffman Coding**.
It supports:

* 📄 Files (`.txt`, `.doc`, `.docx`, `.ppt`, `.pptx`, `.pdf`)
* 🖼 Images (`.jpg`, `.png`, `.bmp`, etc.)
* 📁 Folders (multiple files bundled into a single `.huf` archive)

---

## 🧭 How to Contribute

### 1️⃣ Fork the Repository

* Fork the repo to your GitHub account
* Clone your fork locally

```bash
git clone https://github.com/your-username/ZipITSmart.git
```

---

### 2️⃣ Create a Feature Branch

Always create a new branch for your work:

```bash
git checkout -b feature/your-feature-name
```

Examples:

* `feature/improve-ui`
* `bugfix/folder-decompression`
* `docs/update-readme`

---

### 3️⃣ Follow the Project Structure

Please respect the existing architecture:

```
ZipITSmart/
├── Core/
│   ├── Huffman/
│   ├── Archive/
│   └── Interfaces/
├── Services/
├── Models/
├── UI/
└── Documents/
```

* **Core** → algorithms & low-level logic
* **Services** → compression/decompression logic
* **UI** → Windows Forms
* **Models** → data models & results
* **Documents** → proposals, reports, sprint docs

---

## 🧪 Coding Guidelines

### ✅ General Rules

* Use **clear, descriptive naming**
* Keep methods **single-responsibility**
* Avoid hardcoding paths
* Always dispose streams properly (`using` statements)

### ✅ Compression Rules (Important)

* Always return:

```csharp
OriginalSize   = size before compression
CompressedSize = size after compression
```

* Never invert these values
* Use markers consistently:

  * `'F'` → File
  * `'I'` → Image
  * `'D'` → Folder

### ✅ File Extensions

* All compressed files **must use `.huf`**
* Decompression must restore the original extension

---

## 🧩 UI Contributions

When modifying UI:

* Maintain dropdown-based workflow
* Do not add duplicate buttons for file types
* Use dialogs (`OpenFileDialog`, `SaveFileDialog`, `FolderBrowserDialog`)
* Ensure user-friendly error messages

---

## 📝 Documentation Contributions

We strongly encourage:

* Improving `README.md`
* Adding diagrams
* Writing reports in `/Documents`
* Commenting complex logic (especially Huffman parts)

---

## 🧪 Testing Your Changes

Before submitting:

* Test **File**, **Image**, and **Folder** compression
* Verify:

  * `.huf` file is created
  * Decompressed output matches original
  * Compression statistics are accurate
* Ensure no file-locking issues

---

## 📤 Submitting a Pull Request

1. Push your branch:

```bash
git push origin feature/your-feature-name
```

2. Open a **Pull Request** against `main`
3. Include:

   * Clear title
   * Description of changes
   * Screenshots (for UI changes)
   * Testing details

---

## 🚫 What NOT to Do

* Don’t commit directly to `main`
* Don’t reformat unrelated code
* Don’t break existing compression formats
* Don’t introduce new archive formats without discussion

---

## 👥 Team & Maintainers

This project is maintained by a team of 4:

* **Muhammad Hammad Asher** – Team Lead & Developer
* **Muhammad Affan bin Aamir** – Developer & Designer
* **Samiullah Baig** – Developer
* **Syed Shayan Agha** – Designer, Developer & Documentation

For major changes, please open an issue first.

---

## 📜 License & Academic Use

This project is developed for **educational purposes**.
You are free to:

* Study
* Modify
* Extend

Please provide proper attribution when using or referencing this work.

---

### ⭐ Thank You for Contributing!

Your contributions help make **ZipITSmart** better, smarter, and more robust.

Happy coding! 🚀
