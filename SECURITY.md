# Security Policy 🔐

## Supported Versions

The following versions of **ZipITSmart** are currently supported with security updates:

| Version                 | Supported |
| ----------------------- | --------- |
| Latest (`main` branch)  | ✅ Yes     |
| Older academic releases | ❌ No      |

Only the **latest version on the `main` branch** receives security fixes.

---

## Reporting a Vulnerability 🐛

If you discover a security vulnerability in ZipITSmart, please **do not open a public issue**.

Instead, report it responsibly using one of the following methods:

### 📧 Preferred Method

Contact the maintainers directly via GitHub:

* Open a **private security advisory** (if enabled)
* Or contact a core team member via GitHub profile

### 📄 What to Include

Please include as much detail as possible:

* Description of the vulnerability
* Steps to reproduce
* Affected component (File / Image / Folder compression)
* Screenshots or logs (if applicable)
* Suggested fix (optional)

---

## Response Timeline ⏱️

We aim to respond according to the following timeline:

* **Initial response**: within 48–72 hours
* **Assessment & verification**: within 7 days
* **Fix or mitigation**: as soon as reasonably possible

Since this is an **academic project**, timelines may vary slightly.

---

## Scope of Security Concerns

We consider the following as valid security issues:

* Arbitrary file overwrite during decompression
* Path traversal vulnerabilities
* File-locking or stream misuse leading to data corruption
* Unsafe handling of user-selected paths
* Malformed `.huf` files causing crashes or undefined behavior

The following are **out of scope**:

* UI/UX bugs
* Performance optimizations
* Feature requests
* Non-security-related crashes

---

## Secure Coding Practices 🔒

Contributors are expected to:

* Properly dispose file streams (`using` statements)
* Validate file markers (`'F'`, `'I'`, `'D'`)
* Prevent directory traversal during folder decompression
* Avoid executing or interpreting file contents
* Never trust malformed or tampered `.huf` files

---

## Disclosure Policy 📢

* Security issues will be disclosed **after a fix is implemented**
* Credit will be given to the reporter (unless anonymity is requested)
* No sensitive exploit details will be published prematurely

---

## Academic Integrity Notice 🎓

ZipITSmart is developed primarily for **educational purposes**.
Security reports are welcomed and appreciated, but exploitation for misuse, plagiarism, or grading manipulation is strictly discouraged.

---

## Maintainers 👥

Security issues are handled by the core team:

* **Muhammad Hammad Asher** – Team Lead
* **Muhammad Affan bin Aamir** – Developer
* **Samiullah Baig** – Developer
* **Syed Shayan Agha** – Documentation & Developer

---

Thank you for helping keep **ZipITSmart** safe and reliable! 🛡️
