var loginController = function() {
    this.initialize = function() {
        registerEvents();
    }

    var registerEvents = function() {
        $('#btnLogin').on('click',function(e) {
            e.preventDefault();
            var user = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            login(user, password);
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