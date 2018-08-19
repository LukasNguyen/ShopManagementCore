var loginController = function() {
    this.initialize = function() {
        registerEvents();
    }

    var registerEvents = function () {

        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [], // không bỏ nó ra khỏi validate của form
            //lang: 'vi',
            rules: {
                userName: {
                    required: true
                },
                password: {
                    required: true
                }
            },
            messages: {
                userName: {
                    required: 'Vui lòng nhập tên tài khoản'
                },
                password: {
                    required: 'Vui lòng nhập mật khẩu'
                }
            }
        });

        $('#btnLogin').on('click', function (e) {
            if($('#frmLogin').valid()){
            e.preventDefault();
            var user = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            login(user, password);
            }
        });
    }

    var login = function(user, pass) {
        $.ajax({
            type: "POST",
            data: {
                UserName: user,
                Password:pass
            },
            dataType: 'json',
            url: '/Admin/Login/Authen',
            success:function(res) {
                if (res.Success) {
                    window.location.href = "/Admin/Home/Index";
                } else {
                    lukas.notify('Đăng nhập không thành công', 'error');
                }
            }
        });
    }
}