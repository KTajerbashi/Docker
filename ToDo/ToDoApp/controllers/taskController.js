let tasks = [];

// GET /api/tasks
exports.getAllTasks = (req, res) => {
    res.status(200).json(tasks);
};

// GET /api/tasks/:id
exports.getTaskById = (req, res) => {

    const id = Number(req.params.id);

    const task = tasks.find(t => t.id === id);

    if (!task) {
        return res.status(404).json({
            success: false,
            message: "Task Not Found"
        });
    }

    res.json(task);
};

// POST /api/tasks
exports.createTask = (req, res) => {

    const {

        title,
        description,
        assignee,
        priority,
        startDate,
        endDate,
        status

    } = req.body;

    const task = {

        id: Date.now(),

        title,

        description,

        assignee,

        priority,

        startDate,

        endDate,

        status,

        createdAt: new Date(),

        updatedAt: new Date()

    };

    tasks.push(task);

    res.status(201).json({

        success: true,

        message: "Task Created",

        data: task

    });

};

// PUT /api/tasks/:id
exports.updateTask = (req, res) => {

    const id = Number(req.params.id);

    const index = tasks.findIndex(t => t.id === id);

    if (index === -1) {

        return res.status(404).json({

            success: false,

            message: "Task Not Found"

        });

    }

    tasks[index] = {

        ...tasks[index],

        ...req.body,

        updatedAt: new Date()

    };

    res.json({

        success: true,

        message: "Task Updated",

        data: tasks[index]

    });

};

// DELETE /api/tasks/:id
exports.deleteTask = (req, res) => {

    const id = Number(req.params.id);

    const index = tasks.findIndex(t => t.id === id);

    if (index === -1) {

        return res.status(404).json({

            success: false,

            message: "Task Not Found"

        });

    }

    tasks.splice(index, 1);

    res.json({

        success: true,

        message: "Task Deleted"

    });

};

// PATCH /api/tasks/:id/status
exports.changeStatus = (req, res) => {

    const id = Number(req.params.id);

    const task = tasks.find(t => t.id === id);

    if (!task) {

        return res.status(404).json({

            success: false,

            message: "Task Not Found"

        });

    }

    task.status = req.body.status;

    task.updatedAt = new Date();

    res.json({

        success: true,

        message: "Status Updated",

        data: task

    });

};