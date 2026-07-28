const express = require("express");

const router = express.Router();

const taskController = require("../../controllers/taskController");

// دریافت همه تسک‌ها
router.get("/", taskController.getAllTasks);

// دریافت یک تسک
router.get("/:id", taskController.getTaskById);

// ایجاد تسک
router.post("/", taskController.createTask);

// ویرایش کامل
router.put("/:id", taskController.updateTask);

// تغییر وضعیت
router.patch("/:id/status", taskController.changeStatus);

// حذف
router.delete("/:id", taskController.deleteTask);

module.exports = router;