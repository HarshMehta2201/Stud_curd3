function insertStudent() {
    var valuesArray = $('input[name="Hobbies"]:checkbox:checked').map(function () {
        return this.value;
    }).get().join(",");
    var radioValue = $('input[name="Gender"]:checked').val();
    var userData = {
        Collage_Id: $("#CollegeName").val(),
        Hobby_Id: valuesArray,
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Gender: radioValue,
        Address: $("#Address").val(),
        Stud_Id: $("#Stud_Id").val(),
    }
    $.ajax({
        type: "POST",
        url: "/Student/Insert",
        data: { studentViewModel: userData },
        success: function () {
            alert("Success");
            window.location.href = "/Student/GetStudentList"
        },
        error: function () {
            alert("Fail");
            window.location.href = "/Student/Insert"
        }
    })
}