﻿var BaseController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.add-to-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                data: {
                    productId: id,
                    quantity: 1,
                    colorId: 0,
                    sizeId: 0
                },
                success: function (response) {
                    lukas.notify('The product was added to cart', 'success');
                    loadHeaderCart();
                    //loadMyCart();
                }
            });
        });

        $('body').on('click', '.remove-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveFromCart',
                type: 'post',
                data: {
                    productId: id
                },
                success: function (response) {
                    lukas.notify('The product was removed', 'success');
                    loadHeaderCart();
                    //loadMyCart();
                }
            });
        });
    }

    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }

    //function loadMyCart() {
    //    $("#sidebarCart").load("/AjaxContent/MyCart");
    //}
}