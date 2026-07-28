const express = require("express");
const path = require("path");
//  
const taskRoute = require("./routes/task");
const taskApi = require("./routes/api/taskApi");

const app = express();
const PORT = process.env.PORT || 3000;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Static Files
app.use(express.static(path.join(__dirname, "public")));

app.use("/dashboard", require("./routes/dashboard"));
app.use("/profile", require("./routes/profile"));
app.use("/about", require("./routes/about"));

app.use("/api/tasks", taskApi);
app.use("/tasks", taskRoute);

app.get("/", (req, res) => {
    res.redirect("/dashboard");
});

app.listen(PORT, () => {
    console.log(`Server Running : http://localhost:${PORT}`);
});