let dogs = [];
let owners = [];
let courses = [];
fetch('http://localhost:25294/dog')
    .then(x => x.json()).then(y => {
        dogs = y;
        displayDogs();
    });
fetch('http://localhost:25294/owner')
    .then(x => x.json()).then(y => {
        owners = y;
        displayOwners();
    });
fetch('http://localhost:25294/course')
    .then(x => x.json()).then(y => {
        courses = y;
        displayCourses();
        setTabledata();
    });





function displayDogs() {
    dogs.forEach(d => {
        if (d.sex == 1) { gender = "Szuka" } else { gender = "Kan" };
        if (d.castrated == 1) { castrated = "Igen" } else { castrated = "Nem" };
        document.getElementById('dogs').innerHTML +=
            "<tr><td>" + d.id + "</td><td>" + d.name + "</td><td>" + d.breed + "</td><td>" + gender + "</td><td>" + castrated + "</td><td>" + d.weight + "</td><td>" + d.height + "</td><td>" + d.ownerId + "</td > <td>" + d.courseId + "</td></tr>";
    });
}
function displayOwners() {
    owners.forEach(o => {
        if (o.sex == 1) { gender = "N�" } else { gender = "F�rfi" };
        document.getElementById('owners').innerHTML +=
            "<tr><td>" + o.id + "</td><td>" + o.name + "</td><td>" + o.age + "</td><td>" + gender + "</td><td>"+ o.courseId + "</td></tr>";
    });

}
function displayCourses() {
    courses.forEach(c => {
        document.getElementById('courses').innerHTML +=
            "<tr><td>" + c.id + "</td><td>" + c.name + "</td><td>" + c.organizer + "</td><td>" + c.trainer + "</td></tr>";});
}

function setTabledata() {
    owners.forEach(o => {
        let sel = document.getElementById('oid');
        var option = document.createElement("option");
        option.value = o.id;
        option.text = o.id;
        sel.add(option);
    });
    courses.forEach(c => {
        let sel = document.getElementById('cid');
        var option = document.createElement("option");
        option.value = c.id;
        option.text = c.id;
        sel.add(option);
    });
}