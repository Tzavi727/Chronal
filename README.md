# Chronal

Chronal is a program that tracks your time inside any process, just like Steam does with games, but for anything!

---

## Features

* **Detailed Analytics**
    * Get precise information about your tracked processes: Lifetime Uptime, Current Session duration, real-time Process Status, and the exact date of your Last Session.
* **Process Management**
    * Easily register or remove any Windows process you want to monitor. Use the built-in toggles to enable or disable tracking for specific items without deleting them from your database.
* **Persistent Local Storage**
    * Powered by SQLite and Dapper, all your data is stored locally in a single .db file. Your tracking history remains intact even after closing the program or restarting your PC.
* **Stealth & Performance**
    * Made to be lightweight (~50MB RAM) and non-intrusive. *Chronal* runs in the System Tray, so it won't lag your games or slow down your work.

---

## How To Run

### Option 1: Just get the latest release (Recommended)

1.  Go to the [Latest Release](https://github.com/Tzavi727/Chronal/releases) page.
2.  Download the `Chronal.7z` file.
3.  Extract it anywhere and run **`Chronal.exe`**.

---

### Option 2: Run from the source

1.  **Prerequisites:** You need to have the **.NET SDK** installed on your machine (Version 8.0 or higher recommended).
2.  **Clone the repository:**
    ```bash
    git clone https://github.com/Tzavi727/Chronal.git
    ```
3.  **Navigate to the project folder:**
    ```bash
    cd src/Chronal
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```