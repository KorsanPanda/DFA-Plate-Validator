# 🚗 DFA Plate Validator (Turkish License Plate Format)

![Language](https://img.shields.io/badge/Language-Python%2FJava%2FC%2B%2B-blue.svg)
![Domain](https://img.shields.io/badge/Domain-Formal_Languages_%26_Automata-orange.svg)
![Concept](https://img.shields.io/badge/Concept-DFA_State_Machine-green.svg)
![Category](https://img.shields.io/badge/Category-String_Validation-purple.svg)

A Deterministic Finite Automaton (DFA) implementation developed as part of the **Formal Languages and Automata Theory** course. This tool models a formal state machine to validate string inputs against official **Turkish License Plate (Türkiye Plaka Kodu)** formatting rules.

---

## 📌 Project Overview

Formal languages classify syntactically valid strings using formal grammars and state machines. In Turkey, license plates follow strict standardized patterns based on province codes, letter combinations, and number sequences.

This project designs and implements a formal **DFA (Deterministic Finite Automaton)** tuple $M = (Q, \Sigma, \delta, q_0, F)$ that reads input strings character-by-character, transitions through deterministic states, and determines string acceptance without using regular expression shortcuts.

### Key Features
* **Formal State Machine Implementation:** Explicit transition functions ($\delta$) mapping inputs strictly to deterministic states.
* **Turkish License Plate Formatting Rules:**
  * **Province Code:** 2-digit number ranging from `01` to `81`.
  * **Format 1:** `34 A 1234` (1 Letter, 4 Digits)
  * **Format 2:** `34 AB 123` or `34 AB 1234` (2 Letters, 3 or 4 Digits)
  * **Format 3:** `34 ABC 12` or `34 ABC 123` (3 Letters, 2 or 3 Digits)
* **Rejection Analysis:** Catches illegal province codes (e.g., `00` or `82+`), invalid character sequences, missing spaces, and length mismatches.
* **Step-by-Step State Tracking:** Logs state transitions (e.g., $q_0 \xrightarrow{\text{'3'}} q_1 \xrightarrow{\text{'4'}} q_2 \dots$) for educational demonstration.

---

## ⚙️ Mathematical Formalism (DFA Definition)

The automaton is formally defined as $M = (Q, \Sigma, \delta, q_0, F)$:

* **$Q$ (State Set):** $\{q_0, q_1, q_2, q_{\text{letter1}}, q_{\text{letter2}}, q_{\text{digit1}}, \dots, q_{\text{accept}}, q_{\text{trap}}\}$
* **$\Sigma$ (Alphabet):** $\{0..9\} \cup \{A..Z\} \setminus \{\text{Turkish-specific non-standard characters}\} \cup \{\text{space}\}$
* **$q_0$ (Initial State):** Start state before reading the province code.
* **$\delta$ (Transition Function):** $\delta: Q \times \Sigma \rightarrow Q$
* **$F$ (Accept States):** Valid terminal states reached after complete plate parsing.

---

## 🚀 Getting Started

### Prerequisites
* Python 3.8+ (or GCC / Java depending on your source build environment)

### Execution Steps

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/USERNAME/DFA-Plate-Validator.git](https://github.com/USERNAME/DFA-Plate-Validator.git)
   cd DFA-Plate-Validator
   ```

2. **Run the validator:**
   ```bash
   python main.py
   ```

3. **Interactive Testing:**
   Input candidate plate strings to test validation output:
   * `34 ABC 123` $\rightarrow$ **VALID (Accepted)**
   * `06 A 1234` $\rightarrow$ **VALID (Accepted)**
   * `82 ABC 12` $\rightarrow$ **INVALID (Rejected - Invalid Province Code)**
   * `34 AB 12345` $\rightarrow$ **INVALID (Rejected - Excess Digits)**

---

## 📁 Directory Structure

```text
DFA-Plate-Validator/
├── docs/
│   └── State_Diagram.pdf    # Visual DFA transition graph & formal proof
├── src/
│   ├── dfa_engine.py        # Core state machine execution engine
│   ├── transition_table.py  # Explicit state transition mapping logic
│   └── main.py              # CLI user interface & test suite
└── README.md
```
