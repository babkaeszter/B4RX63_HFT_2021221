let dogs = [];
let owners = [];
let courses = [];
fetch('http://localhost:25294/dog')
    .then(x => x.json()).then(y => {
        dogs = y;
        console.log(y);
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
    dogs.forEach(t => { });
}
function displayCourses() {
    dogs.forEach(t => { });
}