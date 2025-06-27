# 🍰 Bakeshop Management System ✨  
Welcome to the **Bakeshop Management System**, a sweet and smart Windows Forms Application built with 💖 using **C#** and **SQL Server**. Designed to give both customers and admins a delightful experience—from browsing cakes to managing sales with beautiful charts!

---

## 🌟 Overview

This system supports two main users:

- 👩‍🍳 **Admin** – Manages products, tracks sales, handles orders
- 🧁 **Customer** – Browses the menu, adds to cart/favorites, places orders, and views history

Everything is displayed using `UserControls`, with animated panels, smart layouts, and simple interactions. 

---

## 🔐 Account Features

### 📝 Registration  
- 💌 Email must end with **`@gmail.com`** (no exceptions!)
- 🔒 Passwords must be at least **8 characters long**

### 🔑 Login
- 🧁 **Customers** log in with their registered username & password → redirected to `Customer_Menu`
- 👩‍🍳 **Admin** logs in using:
  - **Username:** `admin`
  - **Password:** `roxy`
  → redirected to `Admin_Menu`

---

## 👩‍🍳 Admin Side Features

### 🧾 Admin_Menu – Product Management
- Add a product using the **Add_Product** form:
  - 🍩 **Name**
  - 🖼️ **Image** (auto-cropped so it always looks neat!)
  - 🗂️ **Category**
  - 🧂 **Up to 4 variations with prices** (e.g., Regular, Large, Special)
  - 📝 **Description**

- Each product appears as a **UserControl card** in a scrollable panel:
  - Displays image, name, price(s)
  - Includes:
    - ✏️ **Edit** button
    - 🗑️ **Delete** button

- Search bar with keyword filter 🔍
- Category filter buttons for easy browsing 🍞🍪🍰

---

### 📬 Admin_Orders – Order Management
- View **customer orders** displayed in adorable UserControls 😋
- Mark orders as:
  - ✅ **Completed**
  - ❌ **Cancelled**
- Sort orders by:
  - 🆕 **Newest First**
  - 🕰️ **Oldest First**
  - 💰 **Total Amount**
    - High ➡ Low
    - Low ➡ High

---

### 📊 Admin_Sales – Sales Report

- Uses a **bar chart** to display total sales based on:
  - 📆 **Day**
  - 📅 **Week**
  - 📆 **Month**
  - 📆 **Year**

- Built using `LiveChartsCore` and related NuGet packages:
  - `LiveChartsCore`
  - `LiveChartsCore.SkiaSharpView`
  - `LiveChartsCore.SkiaSharpView.WinForms`

⚠️ **Note:** This report form is in a **separate project** to avoid conflicts caused by chart dependencies in the main form.

#### Also shows:
- 💸 **Total Revenue**
- 🧾 **Total Orders**
- 👥 **Total Unique Buyers**

---

## 🧁 Customer Side Features

### 🏪 Customer_Menu – Sweet Shopping

- View the full menu from Admin using lovely **UserControl cards**
- Each product has:
  - ❤️ **Add to Favorites** button (heart toggles when filled)
  - 🛒 **Add to Cart** button
    - Can choose:
      - 🧂 **Variation**
      - 🔢 **Quantity**

🧺 **Cart Panel**
- Dynamically shows added items
- Quantity can be adjusted using ➕ and ➖
  - If quantity becomes 1 and ➖ is clicked again, item is **deleted**
- 🧾 **Checkout** button:
  - Saves order
  - Marks as **Pending**

---

### 📜 Customer_History – Your Order Journal

View past and ongoing orders, beautifully sorted by status:

- ⏳ **Pending Orders**
- ✅ **Completed Orders**
- ❤️ **Favorite Products**

---

## 🧑‍💻 Technical Stack

| Layer              | Technology                            |
|--------------------|----------------------------------------|
| 🖥️ Frontend (GUI) | Windows Forms in C#                    |
| 🗃️ Backend         | SQL Server (SSMS)                      |
| 🧠 Business Logic  | Clean class-based structure (OOP)      |
| 📊 Charts          | LiveChartsCore for advanced visuals    |
| 🧱 Architecture    | Layered with full Separation of Concerns |

---

## 📁 Projects Breakdown

- 🧁 **Main GUI Project** – Forms for Admin & Customer
- 📊 **Admin_Sales Project** – Standalone project to isolate chart dependencies

---

## 🧡 Credits and Notes

Created with passion for programming and pastries. 🎂  
If you're planning to explore or expand this project, you're more than welcome!  

Pull requests, forks, and stars are sweetly appreciated. 🌟✨

---

## 💌 Contact

For any suggestions or feedback:
📧 Email: yourname@gmail.com  
📦 GitHub: [github.com/yourusername](https://github.com/yourusername)

