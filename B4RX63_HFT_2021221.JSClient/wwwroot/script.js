let dogs = [];
let owners = [];
let courses = [];

getDogs();
getOwners();
getCourses();
async function getDogs() {
    await fetch('http://localhost:25294/dog')
        .then(x => x.json()).then(y => {
            dogs = y;
            console.log(y);
            displayDogs();
        });
}
async function getOwners() {
    await fetch('http://localhost:25294/owner')
        .then(x => x.json()).then(y => {
            owners = y;
            displayOwners();
        });
}

async function getCourses() {
    await fetch('http://localhost:25294/course')
        .then(x => x.json()).then(y => {
            courses = y;
            displayCourses();
            setTabledata();
        });
}





function displayDogs() {
    //document.getElementById('dogs').innerHTML = ""
    dogs.forEach(d => {
        if (d.sex == 1) { gender = "Szuka" } else { gender = "Kan" };
        if (d.castrated == 1) { castrated = "Igen" } else { castrated = "Nem" };
        document.getElementById('dogs').innerHTML +=
            "<tr><td>" + d.id + "</td><td>" + d.name + "</td><td>" + d.breed + "</td><td>" + gender + "</td><td>" + castrated + "</td><td>" + d.weight + "</td><td>" + d.height + "</td><td>" + d.ownerId + "</td > <td>" + d.courseId + "</td><td><button onclick='removeDog()'>Törlés</button></td></tr>";
    });
}
function displayOwners() {
    //document.getElementById('dogs').innerHTML = ""
    owners.forEach(o => {
        if (o.sex == 1) { gender = "Nõ" } else { gender = "Férfi" };
        document.getElementById('owners').innerHTML +=
            "<tr><td>" + o.id + "</td><td>" + o.name + "</td><td>" + o.age + "</td><td>" + gender + "</td><td>" + o.courseId + "</td><td><button onclick='removeOwner()'>Törlés</button></td></tr>";
    });

}
function displayCourses() {
    //document.getElementById('dogs').innerHTML =""
    courses.forEach(c => {
        document.getElementById('courses').innerHTML = "";
        "<tr><td>" + c.id + "</td><td>" + c.name + "</td><td>" + c.organizer + "</td><td>" + c.trainer + "</td><td><button onclick='removeCourse()'>Törlés</button></td></tr>";});
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
        let sel1 = document.getElementById('ocid');
        let sel2 = document.getElementById('dcid');
        var option = document.createElement("option");
        option.value = c.id;
        option.text = c.id;
        sel1.add(option);
        sel2.add(option);
    });
}

function createDog() {
    let dname = document.getElementById("dname").value;
    let breed = document.getElementById("breed").value;
    let dsex = document.getElementById("dsex").value=="female"?"1":"0";
    let castrated = document.getElementById("castrated").value;
    let weight = document.getElementById("weight").value;
    let height = document.getElementById("height").value;
    let oid = document.getElementById("oid").value;
    let dcid = document.getElementById("dcid").value;

    fetch('http://localhost:25294/dog', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name:dname, breed:breed, sex:dsex, castrated:castrated, weight:weight, height:height, ownerId:oid, courseId:dcid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getDogs();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    
}

function createOwner() {
    let oname = document.getElementById("oname").value;
    let age = document.getElementById("age").value;
    let osex = document.getElementById("osex").value == "female" ? "1" : "0";
    let ocid = document.getElementById("ocid").value;

    fetch('http://localhost:25294/owner', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: oname, age: age, sex: osex, courseId: ocid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getOwners();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}
function createCourse() {
    let cname = document.getElementById("cname").value;
    let organizer = document.getElementById("organizer").value;
    let trainer = document.getElementById("trainer");
    

    fetch('http://localhost:25294/course', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: cname, organizer: organizer, trainer: trainer
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getCourses();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}
function removeDog(id) {
    fetch('http://localhost:25294/dog/'+id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function removeOwner(id) {
    fetch('http://localhost:25294/owner/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function removeCourse(id) {
    fetch('http://localhost:25294/course/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}