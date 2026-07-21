# 🚗 DFA Plate Validator (C# Windows Forms)

![Language](https://img.shields.io/badge/Language-C%23-blue.svg)
![Framework](https://img.shields.io/badge/Framework-.NET_Framework_WinForms-green.svg)
![Domain](https://img.shields.io/badge/Domain-Formal_Languages_%26_Automata-orange.svg)
![Concept](https://img.shields.io/badge/Concept-DFA_State_Machine-purple.svg)

A C# Windows Forms desktop application developed for the **Formal Languages and Automata Theory** course. This tool implements a Deterministic Finite Automaton (DFA) state machine to validate string inputs against official **Turkish License Plate (Türkiye Plaka Kodu)** formatting rules.

---

## 📌 Project Overview

Formal languages classify syntactically valid strings using state machines. In Turkey, vehicle license plates follow strict standardized patterns based on province codes (01–81), letter groups, and number sequences.

This application provides a graphical user interface (GUI) where users input candidate license plate strings. The underlying engine processes the input character-by-character through explicit state transitions ($\delta$) without using regular expression shortcuts, giving immediate feedback via the UI.

### Key Features
* **Formal DFA Engine:** Strict deterministic state machine transition logic ($M = (Q, \Sigma, \delta, q_0, F)$).
* **Turkish License Plate Rules:**
  * **Province Code:** 2-digit number ranging from `01` to `81`.
  * **Format 1:** `34 A 1234` (1 Letter, 4 Digits)
  * **Format 2:** `34 AB 123` / `34 AB 1234` (2 Letters, 3 or 4 Digits)
  * **Format 3:** `34 ABC 12` / `34 ABC 123` (3 Letters, 2 or 3 Digits)
* **Windows Forms GUI:** Graphical interface featuring plate text entry (`txtPlaka`), verification trigger (`btnKontrol`), and dynamic validation status display (`lblSonuc`).

---

## 🚀 Getting Started

### Prerequisites
* **Windows OS**
* **Visual Studio** (2017 or newer) with **.NET Desktop Development** workload installed.

### Building and Running

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/KorsanPanda/dfa-plate-validator.git](https://github.com/KorsanPanda/dfa-plate-validator.git)
   cd dfa-plate-validator
   ```

2. **Open and Run in Visual Studio:**
   * Open the project file or solution in **Visual Studio**.
   * Press **F5** or click **Start** to compile and launch the Windows Forms application.

3. **Validation Testing:**
   * `34 ABC 123` $\rightarrow$ **VALID**
   * `06 A 1234` $\rightarrow$ **VALID**
   * `82 ABC 12` $\rightarrow$ **INVALID** (Invalid Province Code)
   * `34 AB 12345` $\rightarrow$ **INVALID** (Excess Digits)

---

## 📁 Directory Structure

```text
korsanpanda-dfa-plate-validator/
├── Form1.cs            # Main C# logic and DFA validation code
├── Form1.Designer.cs   # Windows Forms GUI designer generated code
├── Form1.resx          # Form resource file (embedded images & background assets)
└── README.md           # Project documentation
```
