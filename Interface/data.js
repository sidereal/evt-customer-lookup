var baseUrl = "https://localhost:5001/api/lookup";


function getMyDataWrapper(dataType) {
    hideFeedback();
    $('#dataContainer').empty();
    $('#customerContainer').empty();
    const formData = document.forms["searchForm"]
    const customerId = (formData["customerId"].value).toString();
    var url;
    if (customerId) {
        isLoading(true);
        document.getElementById('ddButton').innerHTML = document.getElementById(dataType).innerHTML;
        switch (dataType) {
            case "info":
                url = `${baseUrl}/customer?id=${customerId}`;
                getMyData(url, displayCustomer);
                break;
            case "agrmnts":
                url = `${baseUrl}/customer/agreements?id=${customerId}`;
                getMyData(url, displayAgreements);
                break;
            case "txn":
                url = `${baseUrl}/customer/txnpage?id=${customerId}&page=1&size=50`;
                counturl = `${baseUrl}/customer/txncount?id=${customerId}`;
                resetCounters();
                getMyTxnData(url, counturl, displayTransactions, displayTxnCount);
            default:
                break;
        }

    }
}

function getMyData(url, output) {

    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    fetch(url, requestOptions)
        .then(response => {
            if (response.status >= 200 && response.status <= 299) {
                return response.json();
            }
            else if (response.status == 404) {
                return response.json()
            }
            else {
                // var x= response.text();
                throw Error(response.status);
            }
        })
        .then(result => output(result))
        .catch(error => {
            displayFeedback(error);
            console.log('error', error)
        })
        .finally(() => {
            isLoading(false);
        });
}

function getMyTxnData(url, counturl, output, countOutput) {

    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    Promise.all([
        fetch(url, requestOptions),
        fetch(counturl, requestOptions)
    ])
        .then(responses => {
            // Get a JSON object from each of the responses
            return Promise.all(responses.map(function (response) {
                return response.json();
            }));
        })
        .then(data => {
            countOutput(data[1]);
            output(data[0]);
            // console.log(data);
        })
        .catch(error => {
            // if there's an error, log it
            displayFeedback(error);
            console.log(error);
        })
        .finally(() => {
            isLoading(false);
        });
}

function formatDate(dateString) {
    var date = new Date(dateString);

    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var day = date.getDate();

    if (day < 10) {
        day = '0' + day;
    }
    if (month < 10) {
        month = '0' + month;
    }
    while (year.toString().length < 4) {
        year = '0' + year;
    }

    var formattedDate = day + '-' + month + '-' + year
    return formattedDate
}

function isLoading(isloading) {
    if (isloading) {
        $('#activitySpinner').removeClass("d-none");
    }
    else {
        $('#activitySpinner').addClass("d-none");
    }

}