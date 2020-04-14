var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Save";
    //$scope.savedata = function () {
    //    $scope.btntext = "Please Wait..."
    //    $http({
    //        method: 'POST',
    //        url: '/Home/insert',
    //        data: $scope.register
    //    }).success(function (d) {
    //        $scope.btntext = "save"
    //        $scope.register = null;
    //        alert("failed");
    //    })
    //}
    $http.get("/Home/ShowRegistration").then(function (d) {
        $scope.ShowRegistration_data = d.data;
    }), function (error) {
        alert("failed");
    }

    function ShowRegistration() {
        $http.get("/Home/ShowRegistration").then(function (d) {
            $scope.ShowRegistration_data = d.data;
        }), function (error) {
            alert("failed");
        }
    }



    function Delete(id) {
        $http.get("/Home/Delete?id=" + id).then(function mySuccess(response) {

            $scope.PageCategory = response.data;
        });
    }
    $(document).on("click", ".save", function () {
        ShowRegistration();

    });

    $(document).on("click", ".delete", function () {
        var id = $(this).attr("id");
        Delete(id);
        location.reload();
    });
    $(document).on("click", ".update", function () {
        var text = "Update Record";

        $(".save").show();
        var id = $(this).attr("id");
        var Name = $(this).attr("name");
        var Email = $(this).attr("Email");
        var Mobile = $(this).attr("Mobile");
        var dob = $(this).attr("dob");
        var age = $(this).attr("age");
        var Course = $(this).attr("Course");
        
        $("#id").val(id);
        $("#Name").val(Name);
        $("#Email").val(Email);
        $("#Mobile").val(Mobile);
        $("#Course").val(Course);
        $("#age").val(age);
        $("#DOB").val(dob);
        $(".save").attr("work", "update");
        $(".save").attr("type", "Button");

    });

    $(document).on("click", ".save", function () {
        var attr = $(this).attr("work", "update");
        if (typeof attr !== typeof undefined && attr !== false) {
            // ...
           var Name= $("#Name").val();
           var Email= $("#Email").val();
           var Mobile= $("#Mobile").val();
           var Course=$("#Course").val();
           var age=$("#age").val();
           var DOB = $("#DOB").val();
           var id = $("#id").val();
           $.ajax({
               url: "/Home/Update",
               type: "POST",
               data: {
                   id:id,
                   Name: Name,
                   Email: Email,
                   Mobile: Mobile,
                   Course: Course,
                   age:age,
                   DOB: DOB

               },
               success: function (data) {

                   alert(data);
                   $(".save").attr("type", "submit")
                   $(".save").removeAttr("work")
                    $("#Name").val('');
                    $("#Email").val('');
                    $("#Mobile").val('');
                  $("#Course").val('');
                   $("#age").val('');
                  $("#DOB").val('');
                  $("#id").val('');
                  location.reload();
                  			
                   }

           
           })
           }

    });







});