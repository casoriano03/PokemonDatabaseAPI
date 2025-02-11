# Pokémon Database Project

## 📌 Project Overview

The **Pokémon Database** is a web application built using **C#** and **Entity Fram****ework**\*\*, designed to store, retrieve, and manage Pokémon data efficiently. The database includes detailed information about each Pokémon, such as stats, abilities, and description*s.*

## 🚀 Featur*es*

- 📊 Store and retrieve Pokémon details (HP, Attack, Defense, Speed, etc.).
- 🔄 Add, update, and delete Pokémon records.
- 🛠️ Built using **C#**, **ASP.NET Core**, and **Entity Framework**.
- 🔐 Secure authentication and role-based access control.

## 🏗️ Technologies Used

- **Backend:** C#, ASP.NET Core, Entity Framework
- **Database:** SQL Server
- **Frontend:** Vue.js
- **Authentication:** JWT for secure login
- **API Calls:** Axios
- **Version Control:** Git & GitHub

## 📂 Project Structure

```
/pokemon-database
│── /Backend
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── Data/
│── /Frontend
│   ├── src/
│   ├── components/
│── README.md
│── .gitignore
│── package.json
│── database.sql
```

## ⚡ Installation & Setup

### 1️⃣ Clone the Repository

```sh
git clone https://github.com/casoriano03/pokemon-database.git
cd pokemon-database
```

### 2️⃣ Backend Setup

- Ensure you have **.NET SDK** installed.
- Navigate to the `Backend/` folder and run:

```sh
dotnet restore
```

- Run database migrations:

```sh
dotnet ef database update
```

- Start the API server:

```sh
dotnet run
```

### 3️⃣ Frontend Setup

- Navigate to the `Frontend/` folder:

```sh
npm install
npm run dev
```

## 🔑 Authentication

- Users must log in with an **email and password**.
- JWT Tokens are used for authentication.
- Admin users have additional permissions to **add, edit, and delete Pokémon data**.

## 📌 API Endpoints

| Method   | Endpoint                                 | Description                      |
| -------- | -----------------------------------------| ---------------------------------|
| `GET`    | `/api/Pokemon`                           | Fetch all Pokémon                |
| `GET`    | `/api/Pokemon/{id}`                      | Fetch a single Pokémon           |
| `POST`   | `/api/Pokemon`                           | Add a new Pokémon (Admin)        |
| `PUT`    | `/api/Pokemon/{id}`                      | Update Pokémon details (Admin)   |
| `DELETE` | `/api/Pokemon/{id}`                      | Delete Pokémon (Admin)           |
| `GET`    | `/api/PokemonStat/GetPokemonStat/{id}`   | Fetch a Pokémon's Stats          |
| `POST`   | `/api/PokemonStat/GetPokemonStat`        | Fetch a Pokémon's Stats (Admin)  |
| `PUT`    | `/api/PokemonStat/EditPokemonStat/{id}​`  | Update a Pokémon's Stats (Admin) |
| `DELETE` | `/api/PokemonStat/DeletePokemonStat/{id}`| Delete a Pokémon's Stats (Admin) |
| `POST`   | `/api/Auth/Register​`                     | Adds a new User                  |
| `POST`   | `/api/Auth/Login​`                        | Authenticates User               |


## 💡 Future Enhancements

✅ Improve UI with animations and better styling. ✅ Add an **AI assistant** that can use endpoints, only for admin use. ✅ **Forgot Password** functionality. ✅ Admin can change a user's role. ✅ Edit profile page. ✅ Support **multiple Pokémon generations**.

## 🤝 Contributing

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature-xyz`).
3. Commit your changes (`git commit -m 'Added new feature'`).
4. Push to the branch (`git push origin feature-xyz`).
5. Open a **Pull Request**.

## 📜 License

This project is licensed under the **MIT License**.

## 📬 Contact

🔗 GitHub: [casoriano03](https://github.com/casoriano03) 📧 Email: [casoriano03@gmail.com](mailto\:casoriano03@gmail.com)

---

🌟 **If you like this project, please ⭐ the repo!**

