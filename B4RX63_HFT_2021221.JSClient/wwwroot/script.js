let dogs = [];
let owners = [];
let courses = [];
let connection=null;
getDogs();
getOwners();
getCourses();
setupSignalR();


//SIGNALR
function setupSignalR() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:25294/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on
        (
            "DogCreated", (user, message) => {
                getDogs();
        });
    connection.on
        (
            "DogDeleted", (user, message) => {
                getDogs();
        });
    connection.on
        (
            "DogUpdated", (user, message) => {
                getDogs();
            });
    connection.on
        (
            "OwnerCreated", (user, message) => {
                getOwners();
        });
    connection.on
        (
            "OwnerDeleted", (user, message) => {
                getOwners();
        });
    connection.on
        (
            "OwnerUpdated", (user, message) => {
                getOwners();
            });
    connection.on
        (
            "CourseCreated", (user, message) => {
                getCourses();
        });
    connection.on
        (
            "CourseDeleted", (user, message) => {
                getCourses();
        });
    connection.on
        (
            "CourseUpdated", (user, message) => {
                getCourses();
            });

    connection.onclose
        (async () => {await start();});
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


//GET FUNCTIONS
async function getDogs() {
    await fetch('http://localhost:25294/dog')
        .then(x => x.json()).then(y => {
            dogs = y;
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



//DISPLAY FUNCTIONS

function displayDogs() {
    //document.getElementById('dogs').innerHTML = ""
    dogs.forEach(d => {
        if (d.sex == 1) { gender = "Szuka" } else { gender = "Kan" };
        if (d.castrated == 1) { castrated = "Igen" } else { castrated = "Nem" };
        document.getElementById('dogs').innerHTML +=
            "<tr><td>" + d.id + "</td><td>" + d.name + "</td><td>" + d.breed + "</td><td>" + gender + "</td><td>" + castrated +
            "</td><td>" + d.weight + "</td><td>" + d.height + "</td><td>" + d.ownerId + "</td > <td>" + d.courseId +
            "</td><td><button onclick='removeDog()'>Törlés</button>" +
        "<button onclick='showUpdateDog("+d.id+")'>Módosítás</button></td ></tr > ";
    });
}
function displayOwners() {
    //document.getElementById('dogs').innerHTML = ""
    owners.forEach(o => {
        if (o.sex == 1) { gender = "Nõ" } else { gender = "Férfi" };
        document.getElementById('owners').innerHTML +=
            "<tr><td>" + o.id + "</td><td>" + o.name + "</td><td>" + o.age + "</td><td>" + gender + "</td><td>" + o.courseId +
            "</td><td><button onclick='removeOwner()'>Törlés</button>" +
        "<button onclick='showUpdateOwner(" + o.id +")'>Módosítás</button></td ></tr > ";
    });

}
function displayCourses() {
    //document.getElementById('dogs').innerHTML =""
    courses.forEach(c => {
        document.getElementById('courses').innerHTML +=
            "<tr><td>" + c.id + "</td><td>" + c.name + "</td><td>" + c.organizer + "</td><td>"
            + c.trainer + "</td><td><button onclick='removeCourse()'>Törlés</button>" +
        "<button onclick='showUpdateCourse(" + c.id +")'>Módosítás</button></td ></tr > ";
    });
}

function setTabledata() {
    owners.forEach(o => {
        let sel1 = document.getElementById('oid');
        let sel2 = document.getElementById('uoid');
        var option = document.createElement("option");
        option.value = o.id;
        option.text = o.id;
        sel1.add(option);
        sel1.add(option);
    });
    courses.forEach(c => {
        let sel1 = document.getElementById('ocid');
        let sel2 = document.getElementById('dcid');
        let sel3 = document.getElementById('udcid');
        var option = document.createElement("option");
        option.value = c.id;
        option.text = c.id;
        sel1.add(option);
        sel2.add(option);
        sel3.add(option);
    });
}

//CREATE FUNCTIONS

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


///DELETE FUNCTIONS
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

//SHOW UPDATE FUNCTIONS

function showUpdateDog(id) {
    let oname = document.getElementById("oname").value;
    let age = document.getElementById("age").value;
    let osex = document.getElementById("osex").value == "female" ? "1" : "0";
    let ocid = document.getElementById("ocid").value;
    document.getElementById("udsex").value == dog["sex"] == "1" ? "female" : "male";
}


function showUpdateOwner(id) {
    document.getElementById("crowner").classList.add("dnone");
    let form = document.getElementById("updateOwner");
    form.classList.remove("dnone");

    let owner = owners.find(o => o['id'] == id);
    document.getElementById("uoid").value = owner['id'];
    document.getElementById("uoname").value=owner['name'];
    document.getElementById("uage").value = owner['age'];
    document.getElementById("uosex").value = owner['sex']=="0"?"male":"female";
    document.getElementById("uocid").value = owner['courseId'];
}

//UPDATE FUNCTIONS

function updateDog() {
    let id = document.getElementById("did").value;
    let dname = document.getElementById("udname").value;
    let breed = document.getElementById("ubreed").value;
    let dsex = document.getElementById("udsex").value == "female" ? "1" : "0";
    let castrated = document.getElementById("ucastrated").checked;
    let weight = document.getElementById("uweight").value;
    let height = document.getElementById("uheight").value;
    let oid = document.getElementById("uoid").value;
    let dcid = document.getElementById("udcid").value;

    fetch('http://localhost:25294/dog', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
               id:id, name: dname, breed: breed, sex: dsex, castrated: castrated, weight: weight, height: height, ownerId: oid, courseId: dcid
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
function updateOwner() {
    let oid = document.getElementById("uoid").value;
    let oname = document.getElementById("uoname").value;
    let age = document.getElementById("uage").value;
    let osex = document.getElementById("uosex").value == "female" ? "1" : "0";
    let ocid = document.getElementById("uocid").value;

    fetch('http://localhost:25294/owner', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
               id:oid, name: oname, age: age, sex: osex, courseId: ocid
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