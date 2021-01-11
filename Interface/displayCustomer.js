function displayCustomer(data) {
    if (data.hasOwnProperty('message')) {
        displayFeedback(data['message'])
    }
    else if (data) {
        //let message = `found ${data.length} agreements`;
        displayFeedback(`found customer ${data['id']}`);
        buildCustomer(data);
        // var element = document.getElementById("dataContainer");

    }

    console.log(data);
}


function buildCustomer(data) {
    var card = document.createElement("div");
    card.className = "card m-1";

    var cardBody = document.createElement('div');
    cardBody.className = "card-body";

    var cardHeader = document.createElement('div');
    cardHeader.className = "card-header";

    var cardTitle = document.createElement('h5');
    cardTitle.className = "card-title";
    var cardTitleContent = document.createTextNode(data['id']);
    cardTitle.appendChild(cardTitleContent);

    var segmentContainer = document.createElement('div');
    segmentContainer.className = "d-flex";

    var segment = document.createElement('p');
    segment.className = "border rounded align-middle m-1 p-1";
    var segmentContent = document.createTextNode(`Segment: ${data['segment']}`);
    segment.appendChild(segmentContent);

    var status = document.createElement('p');
    status.className = "border rounded align-middle m-1 p-1";
    var statusContent = document.createTextNode(`Status: ${data['status']}`);
    status.appendChild(statusContent);
    //end header
    //start body

    var bodyContainer = document.createElement('div');
    bodyContainer.className = "d-flex flex-wrap";

    var type = document.createElement('p');
    type.className = "border rounded align-middle m-1 p-1";
    var typeContent = document.createTextNode(`Type: ${data['type']}`);
    type.appendChild(typeContent);

    var banker = document.createElement('p');
    banker.className = "border rounded align-middle m-1 p-1";
    var bankerContent = document.createTextNode(`Banker: ${data['banker']}`);
    banker.appendChild(bankerContent);

    //start Birthdate
    var birthDateContainer = document.createElement('div');
    birthDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var birthdateDescription = document.createElement('div');
    var birthDateDescriptionContent = document.createTextNode("Birthdate:");
    birthdateDescription.appendChild(birthDateDescriptionContent);

    var birthDate = document.createElement('div');
    birthDate.className = "mx-1";
    var birthDateContent = document.createTextNode(`${formatDate(data['birthDate'])}`);

    birthDate.appendChild(birthDateContent);
    birthDateContainer.appendChild(birthdateDescription);
    birthDateContainer.appendChild(birthDate);

    //end Birthdate

    //start Last Contact Date
    var lastContactDateContainer = document.createElement('div');
    lastContactDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var lastContactDateDescription = document.createElement('div');
    var lastContactDateDescriptionContent = document.createTextNode("Last Contact:");
    lastContactDateDescription.appendChild(lastContactDateDescriptionContent);

    var lastContactDate = document.createElement('div');
    lastContactDate.className = "mx-1";
    var lastContactDateContent = document.createTextNode(`${formatDate(data['lastContact'])}`);
    lastContactDate.appendChild(lastContactDateContent);

    lastContactDateContainer.appendChild(lastContactDateDescription);
    lastContactDateContainer.appendChild(lastContactDate);
    //end Last Contact date

    //start next Contact Date
    var nextContactDateContainer = document.createElement('div');
    nextContactDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var nextContactDateDescription = document.createElement('div');
    var nextContactDateDescriptionContent = document.createTextNode("Next Contact:");
    nextContactDateDescription.appendChild(nextContactDateDescriptionContent);

    var nextContactDate = document.createElement('div');
    nextContactDate.className = "mx-1";
    var nextContactDateContent = document.createTextNode(`${formatDate(data['nextContact'])}`);
    nextContactDate.appendChild(nextContactDateContent);

    nextContactDateContainer.appendChild(nextContactDateDescription);
    nextContactDateContainer.appendChild(nextContactDate);
    //end next Contact date




    //build the thing
    bodyContainer.appendChild(banker);
    bodyContainer.appendChild(birthDateContainer);
    bodyContainer.appendChild(lastContactDateContainer);
    bodyContainer.appendChild(nextContactDateContainer);


    cardBody.appendChild(bodyContainer);

    segmentContainer.appendChild(segment);
    segmentContainer.appendChild(status);

    cardHeader.appendChild(cardTitle);
    cardHeader.appendChild(segmentContainer)
    card.appendChild(cardHeader);
    card.appendChild(cardBody);
    $('#customerContainer').append(card);


}