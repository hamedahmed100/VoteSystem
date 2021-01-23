
$(document).ready(function () {
    var i = 1;
    $("#addAnswer").click(function () {
        $("#answers").append(" <div class='form-group'>  <label for='Answer-1'>Answer-" + (i + 1) +"</label>  <input type='text' required name='Answers' class='form-control' id='Answer' placeholder='Enter The Answer'></div>");
        i++;
    });


});