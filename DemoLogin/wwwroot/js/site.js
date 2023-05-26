// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Skillpagination(num) {
    $.ajax({
        url: '/Admin/SkillNew',
        method: 'POST',
        data: {
            PageNumber: num
        },
        success: function (data) {
            $('#SkillTable').html(data);
        },
        error: function(err) {
            console.error(err.responseText);
        }
    });
}

function DeleteSkill(num) {
    $('#delete-row').click(function () {
        $.ajax({
            url: '/Admin/DeleteSkill',
            method: 'POST',
            data: {
                Id : num
            },
            success: function (data) {
                    $('#Skill' + num).remove();
            },
            error: function (err) {
                console.log(err.responseText);
            }
        })
    })
}

function EditSkill(num) {
    $('#Edit-Skill-Name').val($('#SkillName' + num).html());
    var sta = $('#SkillStatus' + num).html()
    if (sta == 'True') {
        $('#Edit-Skill-Status').val(1);
    }
    else {
        $('#Edit-Skill-Status').val(0);
    }

    $('#edit-row').click(function (e) {
        e.preventDefault();
        var skill = $('#Edit-Skill-Name').val();
        var status = $('#Edit-Skill-Status').val();

        $.ajax({
            url: '/Admin/EditSkill',
            method: 'POST',
            data: {
                Id: num,
                SkillName: skill,
                Status: status
            },
            success: function (data) {
                $('#SkillName' + num).html(skill);
                if (status == 1) {
                    $('#SkillStatus' + num).html("True");
                }
                else {
                    $('#SkillStatus' + num).html("False");
                }
            },
            error: function (err) {
                console.log(err.responseText);
            }
        });
    });

    
}

function AddRow() {
    $('#edit-row').click(function () {

        var skill = $('#Edit-Skill-Name').val();
        var status = $('#Edit-Skill-Status').val();

        $.ajax({
            url: '/Admin/AddSkill',
            method: 'POST',
            data: {
                SkillName: skill,
                Status: status
            },
            success: function (data) {
                tostr.success("Skill Added SuccessFully!");
            },
            error: function (err) {
                console.log(err.responseText);
                tostr.error("Skill Can't Be Added!");
            }
        });
    });
}