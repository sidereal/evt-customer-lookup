// var baseUrl = "https://localhost:5001/api/lookup";
var page = 1;
var count = 0
var maxPages = 0

function resetCounters(){
    page = 1;
    count = 0
    maxPages = 0
}


function displayTxnCount(data) {
    if (data.hasOwnProperty('message')) {
        displayFeedback(data['message'])
    }
    else {
        count = data;
        maxPages = math.floor((count - 1) / 50 + 1);
        let message = `found ${data} Transactions`;
        displayFeedback(message);
    }
}

function displayTransactions(data) {
    if (data.hasOwnProperty('message')) {
        displayFeedback(data['message'])
    }
    else if (data.length) {
        let message = `found ${data.length} Transactions`;
        //displayFeedback(message);
        buildTable(data);
    }
    console.log(data);
}

function buildTransaction2(data) {
    var card = document.createElement("div");
    card.className = "card m-1";
    // card.style="width: 24rem";

    var cardBody = document.createElement('div');
    cardBody.className = "card-body";

    var cardHeader = document.createElement('div');
    cardHeader.className = "card-header";


    var cardTitle = document.createElement('h5');
    cardTitle.className = "card-title";
    var cardTitleContent = document.createTextNode(data['id']);
    cardTitle.appendChild(cardTitleContent);

    var productContainer = document.createElement('div');
    productContainer.className = "d-flex";

    var product = document.createElement('p');
    product.className = "border rounded align-middle m-1 p-1";
    var productContent = document.createTextNode(`Product: ${data['productId']}`);
    product.appendChild(productContent);

    var status = document.createElement('p');
    status.className = "border rounded align-middle m-1 p-1";
    var statusContent = document.createTextNode(`Status: ${data['status']}`);
    status.appendChild(statusContent);

    // start dates

    var datesContainer = document.createElement('div');
    datesContainer.className = "d-flex";

    //start open date
    var cardOpenDateContainer = document.createElement('div');
    cardOpenDateContainer.className = "d-flex  flex-wrap align-items-center border rounded  m-1 p-1";

    var cardOpenDateDescription = document.createElement('div');
    var cardOpenDateDescriptionContent = document.createTextNode("Open Date:");
    cardOpenDateDescription.appendChild(cardOpenDateDescriptionContent);

    var cardOpenDate = document.createElement('div');
    cardOpenDate.className = "mx-1";
    var cardOpenDateContent = document.createTextNode(`${formatDate(data['openDate'])}`);
    cardOpenDate.appendChild(cardOpenDateContent);

    cardOpenDateContainer.appendChild(cardOpenDateDescription);
    cardOpenDateContainer.appendChild(cardOpenDate);

    //end open date
    //start close date

    var cardCloseDateContainer = document.createElement('div');
    cardCloseDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardCloseDateDescription = document.createElement('div');
    var cardCloseDateDescriptionContent = document.createTextNode("Close Date:");
    cardCloseDateDescription.appendChild(cardCloseDateDescriptionContent);

    var cardCloseDate = document.createElement('div');
    cardCloseDate.className = "mx-1";
    var cardCloseDateContent = document.createTextNode(`${formatDate(data['closeDate'])}`);
    cardCloseDate.appendChild(cardCloseDateContent);

    cardCloseDateContainer.appendChild(cardCloseDateDescription);
    cardCloseDateContainer.appendChild(cardCloseDate);

    //end close date
    //end dates

    //start payment dates
    var paymentDatesContainer = document.createElement('div');
    paymentDatesContainer.className = "d-flex";

    //start Last Payment Date
    var cardLastPaymentDateContainer = document.createElement('div');
    cardLastPaymentDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardLastPaymentDateDescription = document.createElement('div');
    var cardLastPaymentDateDescriptionContent = document.createTextNode("Last Payment:");
    cardLastPaymentDateDescription.appendChild(cardLastPaymentDateDescriptionContent);

    var cardLastPaymentDate = document.createElement('div');
    cardLastPaymentDate.className = "mx-1";
    var cardLastPaymentDateContent = document.createTextNode(`${formatDate(data['lastPaymentDate'])}`);
    cardLastPaymentDate.appendChild(cardLastPaymentDateContent);

    cardLastPaymentDateContainer.appendChild(cardLastPaymentDateDescription);
    cardLastPaymentDateContainer.appendChild(cardLastPaymentDate);
    //end last payment date

    //start Next Payment Date
    var cardNextPaymentDateContainer = document.createElement('div');
    cardNextPaymentDateContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardNextPaymentDateDescription = document.createElement('div');
    var cardNextPaymentDateDescriptionContent = document.createTextNode("Next Payment:");
    cardNextPaymentDateDescription.appendChild(cardNextPaymentDateDescriptionContent);

    var cardNextPaymentDate = document.createElement('div');
    cardNextPaymentDate.className = "mx-1";
    var cardNextPaymentDateContent = document.createTextNode(`${formatDate(data['nextPaymentDate'])}`);
    cardNextPaymentDate.appendChild(cardNextPaymentDateContent);

    cardNextPaymentDateContainer.appendChild(cardNextPaymentDateDescription);
    cardNextPaymentDateContainer.appendChild(cardNextPaymentDate);
    //end Next payment date

    //start amounts

    var amountsContainer = document.createElement('div');
    amountsContainer.className = "d-flex flex-wrap";

    //start amount
    var cardAmountContainer = document.createElement('div');
    cardAmountContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardAmountDescription = document.createElement('div');
    var cardAmountDescriptionContent = document.createTextNode("Amount:");
    cardAmountDescription.appendChild(cardAmountDescriptionContent);

    var cardAmount = document.createElement('div');
    cardAmount.className = "mx-1";
    var cardAmountContent = document.createTextNode(data['amount']);
    cardAmount.appendChild(cardAmountContent);

    cardAmountContainer.appendChild(cardAmountDescription);
    cardAmountContainer.appendChild(cardAmount);
    //end amount

    //start Limit
    var cardLimitContainer = document.createElement('div');
    cardLimitContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardLimitDescription = document.createElement('div');
    var cardLimitDescriptionContent = document.createTextNode("Limit:");
    cardLimitDescription.appendChild(cardLimitDescriptionContent);

    var cardLimit = document.createElement('div');
    cardLimit.className = "mx-1";
    var cardLimitContent = document.createTextNode(data['limit']);
    cardLimit.appendChild(cardLimitContent);

    cardLimitContainer.appendChild(cardLimitDescription);
    cardLimitContainer.appendChild(cardLimit);
    //end Limit

    //start Balance
    var cardBalanceContainer = document.createElement('div');
    cardBalanceContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardBalanceDescription = document.createElement('div');
    var cardBalanceDescriptionContent = document.createTextNode("Balance:");
    cardBalanceDescription.appendChild(cardBalanceDescriptionContent);

    var cardBalance = document.createElement('div');
    cardBalance.className = "mx-1";
    var cardBalanceContent = document.createTextNode(data['balance']);
    cardBalance.appendChild(cardBalanceContent);

    cardBalanceContainer.appendChild(cardBalanceDescription);
    cardBalanceContainer.appendChild(cardBalance);
    //end Balance


    //end amounts

    //start abw

    var abwContainer = document.createElement('div');
    abwContainer.className = "d-flex flex-wrap";

    //start ObjId
    var cardObjIdContainer = document.createElement('div');
    cardObjIdContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardObjIdDescription = document.createElement('div');
    var cardObjIdDescriptionContent = document.createTextNode("ObjId:");
    cardObjIdDescription.appendChild(cardObjIdDescriptionContent);

    var cardObjId = document.createElement('div');
    cardObjId.className = "mx-1";
    var cardObjIdContent = document.createTextNode(data['abwObjId']);
    cardObjId.appendChild(cardObjIdContent);

    cardObjIdContainer.appendChild(cardObjIdDescription);
    cardObjIdContainer.appendChild(cardObjId);
    //end ObjId

    //start ObjTypSchl
    var cardObjTypSchlContainer = document.createElement('div');
    cardObjTypSchlContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardObjTypSchlDescription = document.createElement('div');
    var cardObjTypSchlDescriptionContent = document.createTextNode("ObjTypSchl:");
    cardObjTypSchlDescription.appendChild(cardObjTypSchlDescriptionContent);

    var cardObjTypSchl = document.createElement('div');
    cardObjTypSchl.className = "mx-1";
    var cardObjTypSchlContent = document.createTextNode(data['abwObjTypSchl']);
    cardObjTypSchl.appendChild(cardObjTypSchlContent);

    cardObjTypSchlContainer.appendChild(cardObjTypSchlDescription);
    cardObjTypSchlContainer.appendChild(cardObjTypSchl);
    //end ObjTypSchl

    //start ObjWhgSchl
    var cardObjWhgSchlContainer = document.createElement('div');
    cardObjWhgSchlContainer.className = "d-flex flex-wrap align-items-center border rounded  m-1 p-1";

    var cardObjWhgSchlDescription = document.createElement('div');
    var cardObjWhgSchlDescriptionContent = document.createTextNode("ObjWhgSchl:");
    cardObjWhgSchlDescription.appendChild(cardObjWhgSchlDescriptionContent);

    var cardObjWhgSchl = document.createElement('div');
    cardObjWhgSchl.className = "mx-1";
    var cardObjWhgSchlContent = document.createTextNode(data['abwObjWhgSchl']);
    cardObjWhgSchl.appendChild(cardObjWhgSchlContent);

    cardObjWhgSchlContainer.appendChild(cardObjWhgSchlDescription);
    cardObjWhgSchlContainer.appendChild(cardObjWhgSchl);
    //end ObjWhgSchl


    //end abw
    abwContainer.appendChild(cardObjIdContainer);
    abwContainer.appendChild(cardObjTypSchlContainer);
    abwContainer.appendChild(cardObjWhgSchlContainer);

    amountsContainer.appendChild(cardAmountContainer);
    amountsContainer.appendChild(cardLimitContainer);
    amountsContainer.appendChild(cardBalanceContainer);

    datesContainer.appendChild(cardOpenDateContainer);
    datesContainer.appendChild(cardCloseDateContainer);

    paymentDatesContainer.appendChild(cardLastPaymentDateContainer);
    paymentDatesContainer.appendChild(cardNextPaymentDateContainer);

    productContainer.appendChild(product);
    // productContainer.appendChild(status);

    cardBody.appendChild(datesContainer);
    cardBody.appendChild(paymentDatesContainer);
    cardBody.appendChild(amountsContainer);
    cardBody.appendChild(abwContainer);

    cardHeader.appendChild(cardTitle);
    cardHeader.appendChild(productContainer);
    card.appendChild(cardHeader);
    card.appendChild(cardBody);
    $('#dataContainer').append(card);
}

function buildTable(data) {
    var cid = data[0]['customerId'];

    var navButtons = document.createElement('div');
    navButtons.className = "d-flex btn-group m-2";
    var nextButton = document.createElement('button');
    var nextButtonText = document.createTextNode('Next');
    nextButton.appendChild(nextButtonText);

    var prevButton = document.createElement('button');
    var prevButtonText = document.createTextNode('Previous');
    prevButton.appendChild(prevButtonText);

    var pageButton = document.createElement('button');
    var pageButtonText = document.createTextNode(`Page ${page} of ${maxPages}`);
    pageButton.appendChild(pageButtonText);

    nextButton.addEventListener("click", function () { showNextPage(cid) });
    prevButton.addEventListener("click", function () { showPrevPage(cid) });

    nextButton.className = "btn btn-outline-secondary";
    pageButton.className = "btn btn-outline-secondary";
    prevButton.className = "btn btn-outline-secondary";

    navButtons.appendChild(prevButton);
    navButtons.appendChild(pageButton);
    navButtons.appendChild(nextButton);

    var txnTable = document.createElement('Table');
    txnTable.className = "table table-striped table-hover table-sm table-bordered w-auto";

    var txnTableHead = document.createElement('thead');
    var headerRow = document.createElement('tr');

    var txnTableBody = document.createElement('tbody');

    for (i = 0; i < txnFields.length; i++) {
        var header = document.createElement('th');
        var headerText = document.createTextNode(txnFields[i]);
        header.scope = "col";
        header.appendChild(headerText);
        headerRow.appendChild(header);
    }

    txnTableHead.appendChild(headerRow);

    data.forEach(element => {
        txnTableBody.appendChild(buildTransaction(element))
    });


    txnTable.appendChild(txnTableHead);
    txnTable.appendChild(txnTableBody);

    $('#dataContainer').append(navButtons);
    $('#dataContainer').append(txnTable);

}

function buildTransaction(data) {

    var dataRow = document.createElement('tr');
    for (i = 0; i < txnFields.length; i++) {
        var dataElement = document.createElement('td');
        dataElement.className = "text-nowrap"
        var dataContent = document.createTextNode(data[txnFields[i]]);

        if (txnFields[i] == 'txnDate') {
            dataContent = document.createTextNode(`${formatDate(data[txnFields[i]])}`);
        }

        dataElement.appendChild(dataContent)
        dataRow.appendChild(dataElement);
    }
    return dataRow;

}

function showNextPage(customerId) {
    page++;
    if (maxPages < page) page = maxPages;

    txnGetPages(page, customerId);
    console.log([page]);
}

function showPrevPage(customerId) {
    page--
    if (page < 1) page = 1;
    txnGetPages(page, customerId);
    console.log(page);
}

function txnGetPages(page, customerId) {
    $('#dataContainer').empty();
    $('#customerContainer').empty();
    url = `${baseUrl}/customer/txnpage?id=${customerId}&page=${page}&size=50`;
    counturl = `${baseUrl}/customer/txncount?id=${customerId}`;
    getMyTxnData(url, counturl, displayTransactions, displayTxnCount);
}


var txnFields = ['id', 'agreementId', 'productId', 'txnDate', 'txnAmount', 'salaryFlag', 'currencyCode', 'txnCurAmount', 'corrAccount', 'corrName', 'corrBank', 'corrCountry', 'txnText']