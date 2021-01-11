function displayFeedback(message){
    $('#feedbackMessageWrapper').removeClass("d-none").addClass("d-flex");
    $('#feedbackMessage').html(message);
}

function hideFeedback(){
    $('#feedbackMessageWrapper').addClass("d-none").removeClass("d-flex");
}