let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

let editId = null;

const modal = document.getElementById("taskModal");

const btnOpen = document.getElementById("btnOpen");
const btnClose = document.getElementById("closeModal");
const btnSave = document.getElementById("saveTask");

btnOpen.onclick = () => {
    clearForm();
    editId = null;
    modal.style.display = "flex";
};

btnClose.onclick = () => {
    modal.style.display = "none";
};

window.onclick = (e) => {
    if (e.target === modal)
        modal.style.display = "none";
};

btnSave.onclick = saveTask;

document
    .getElementById("search")
    .addEventListener("keyup", renderTasks);

document
    .getElementById("filterStatus")
    .addEventListener("change", renderTasks);

function saveTask() {

    const task = {

        id: editId || Date.now(),

        title: document.getElementById("title").value,

        description: document.getElementById("description").value,

        assignee: document.getElementById("assignee").value,

        priority: document.getElementById("priority").value,

        startDate: document.getElementById("startDate").value,

        endDate: document.getElementById("endDate").value,

        status: document.getElementById("status").value

    };

    if (!task.title.trim()) {

        alert("عنوان را وارد کنید");

        return;

    }

    if (editId == null) {

        tasks.push(task);

    } else {

        const index = tasks.findIndex(x => x.id == editId);

        tasks[index] = task;

    }

    localStorage.setItem("tasks", JSON.stringify(tasks));

    modal.style.display = "none";

    clearForm();

    renderTasks();

}

function renderTasks() {

    const tbody = document.getElementById("taskTable");

    tbody.innerHTML = "";

    const keyword = document
        .getElementById("search")
        .value
        .toLowerCase();

    const filter = document
        .getElementById("filterStatus")
        .value;

    let list = tasks.filter(x => {

        let ok1 = x.title.toLowerCase().includes(keyword);

        let ok2 = filter == "" || x.status == filter;

        return ok1 && ok2;

    });

    list.forEach((task, index) => {

        tbody.innerHTML += `

<tr>

<td>${index + 1}</td>

<td>${task.title}</td>

<td>${task.assignee}</td>

<td>${task.priority}</td>

<td>${task.startDate}</td>

<td>${task.endDate}</td>

<td>

<span class="badge ${badgeClass(task.status)}">

${task.status}

</span>

</td>

<td>

<button
class="action edit"
onclick="editTask(${task.id})">

ویرایش

</button>

<button
class="action delete"
onclick="deleteTask(${task.id})">

حذف

</button>

</td>

</tr>

`;

    });

    updateDashboard();

}

function badgeClass(status) {

    switch (status) {

        case "ثبت شده":

            return "registered";

        case "درحال انجام":

            return "progress";

        case "انجام شده":

            return "done";

        case "تایید شده":

            return "approved";

        case "پایان یافته":

            return "finished";

        case "برگشت خورده":

            return "rejected";

    }

}

function editTask(id) {

    const task = tasks.find(x => x.id == id);

    editId = id;

    document.getElementById("title").value = task.title;

    document.getElementById("description").value = task.description;

    document.getElementById("assignee").value = task.assignee;

    document.getElementById("priority").value = task.priority;

    document.getElementById("startDate").value = task.startDate;

    document.getElementById("endDate").value = task.endDate;

    document.getElementById("status").value = task.status;

    modal.style.display = "flex";

}

function deleteTask(id) {

    if (!confirm("حذف شود؟"))
        return;

    tasks = tasks.filter(x => x.id != id);

    localStorage.setItem("tasks", JSON.stringify(tasks));

    renderTasks();

}

function updateDashboard() {

    document.getElementById("registeredCount").innerText =
        tasks.filter(x => x.status == "ثبت شده").length;

    document.getElementById("progressCount").innerText =
        tasks.filter(x => x.status == "درحال انجام").length;

    document.getElementById("doneCount").innerText =
        tasks.filter(x => x.status == "انجام شده").length;

    document.getElementById("approvedCount").innerText =
        tasks.filter(x => x.status == "تایید شده").length;

    document.getElementById("finishedCount").innerText =
        tasks.filter(x => x.status == "پایان یافته").length;

    document.getElementById("rejectedCount").innerText =
        tasks.filter(x => x.status == "برگشت خورده").length;

}

function clearForm() {

    document.getElementById("title").value = "";

    document.getElementById("description").value = "";

    document.getElementById("assignee").value = "";

    document.getElementById("priority").value = "کم";

    document.getElementById("startDate").value = "";

    document.getElementById("endDate").value = "";

    document.getElementById("status").value = "ثبت شده";

}

renderTasks();