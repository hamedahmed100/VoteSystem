
$(document).ready(function () {
    var i = 1;
    $("#addAnswer").click(function () {
        i = $("#answers").find($("input")).length;
        $("#answers").append("<div id='answers"+(i+1)+"'>"
            + "<label for= 'Answer-" + (i + 1) +"'>Answer-" + (i + 1) +"</label>"
            + "<div class='input-group'>"
            + "<input type='text' required name='Answers' class='form-control' id='Answer" + (i + 1) +"'"
            + "placeholder='Enter The Answer' style='margin-bottom: 20px;margin-right: 10px'>"
            + "<div class='input-group-btn'>"
            + "<button onclick=$('#answers" + (i + 1) +"').remove(); class='btn btn-danger' type='button'>remove!</button>"
            + "</div>"
            + "</div>"
            + "</div>");


       // i++;
    });


});