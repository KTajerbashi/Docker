const express = require("express");
const path = require("path");

const router = express.Router();

// صفحه مدیریت تسک
router.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, "../views/task.html"));
});

module.exports = router;