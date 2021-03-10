var cardapio = function () {

    var controles = function () {
        return {
            tableCardapio: '#tabela',
            btnSubmit: '#btnSubmit',
            value: '#Value',
            valueValid: '#ValueValid',
            One: '#One',
            OneValid: '#OneValid',
            Five: '#Five',
            FiveValid: '#FiveValid',
            Ten: '#Ten',
            TenValid: '#TenValid',
            TwentyFive: '#TwentyFive',
            TwentyFiveValid: '#TwentyFiveValid',
            Fifty: '#Fifty',
            FiftyValid: '#FiftyValid',
            OneHundred: '#OneHundred',
            OneHundredValid: '#OneHundredValid',
        };
    }

    //var getFiltros = function () {
    //    var dtoPesquisa = {

    //    };

    //    return dtoPesquisa;
    //}

    //var pesquisar = function () {

    //    mostrarLoading();

    //    $.ajax({
    //        type: "POST",
    //        url: base_path + "MenuHome/ListaTabela",
    //        data: {
    //            'dto': getFiltros()
    //        },
    //        cache: false,
    //        complete: function (XMLHttpRequest, textStatus) {
    //        }
    //    }).done(function (data) {
    //        if (data) {

    //        }
    //    }).fail(function (XMLHttpRequest, textStatus, errorThrown) {
    //        mostrarErroPopup('Problemas ao carregar a pesquisa de Ativo. ' + errorThrown);
    //    });
    //}

    var getModal = function (linhaDataTable) {
        var linha = ExtrairObjeto(linhaDataTable, controles().tableCardapio);

        mostrarLoading();
        $.ajax({
            type: "Get",
            url: base_path + "Menu/NewOrder",
            data:
            {
                "value": linha.value
            },
            cache: false,
        }).done(function (data) {
            montaModal(data);

        }).fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert('Problemas ao carregar Novo Membro. ' + errorThrown);
        });
    }

    var montaModal = function (html) {
        adicionarHtmlPopupTitleBar('modal_new_order', 'form_new_order', 'Novo pedido');

        $("#form_new_order").html(html);

        montarModalComEfeito('#form_new_order', null, 400).on("dialogclose", function (event, ui) {
            $('#form_new_order').remove();
            return false;
        });

        removerLoading();
    }

    var montarTabela = function () {
        $(controles().tableCardapio).DataTable({
            responsive: true,
            dom: 'Bfrtip',
            buttons: [
                { extend: "excelHtml5", className: "buttonsToHide" }
            ],
            data: storageList,
            destroy: true,
            filter: false,
            info: false,
            paginate: true,
            paginationType: 'full_numbers',
            lengthChange: false,
            iDisplayLength: 20,
            language: {
                processing: 'Processando...',
                zeroRecords: 'Nenhum registro encontrado.',
                paginate: {
                    first: '&laquo;',
                    previous: '<',
                    next: '>',
                    last: '&raquo;'
                }
            },
            order: [[0, 'asc']],
            columns: [
                {
                    data: 'name',
                    title: 'Nome',
                    visible: true,
                    sortable: true,
                    render: function (data) {
                        if (data)
                            return data;
                        else
                            return "Sem nome";
                    }
                },
                {
                    data: 'value',
                    title: 'Preço',
                    visible: true,
                    sortable: true,
                    render: function (data) {
                        if (data)
                            return "R$" + data;
                        else
                            return "Sem preço";
                    }
                },
                {
                    data: 'energy',
                    title: 'Energia',
                    sortable: true,
                    render: function (data) {
                        if (data)
                            return data;
                        else
                            return "Sem energia";
                    }
                },
                {
                    data: 'description',
                    title: 'Descrição',
                    sortable: true,
                    render: function (data) {
                        if (data)
                            return data;
                        else
                            return "Sem descrição";
                    }
                },
                {
                    data: null,
                    title: 'Ações',
                    sortable: true,
                    render: function (data) {
                        var html = "";

                        html = "<a style='cursor: pointer;' title='Pedir' data-toggle='tooltip' onclick='cardapio().getModal(this); return false;' data-original-title='Pedir' style='padding:3px;'>"
                            + "<i class='bi bi-file-text'>"
                            + "</a>";
                        return html;
                    }
                }
            ]
        })

        removerLoading();
        $('.buttonsToHide').addClass('hide');
    }

    var validSubmit = function () {
        if ($(controles().One).val() > 0 || $(controles().Five).val() > 0) {
            if ($(controles().One).val() > 0)
                $(controles().OneValid).text("Não estamos aceitando moedas de R$0,01");
            if ($(controles().Five).val() > 0)
                $(controles().FiveValid).text("Não estamos aceitando moedas de R$0,05");

            return false;
        }
        else {
            var money = ($(controles().Ten).val() * 0.10) +
                ($(controles().TwentyFive).val() * 0.25) +
                ($(controles().Fifty).val() * 0.50) +
                ($(controles().OneHundred).val() * 1);

            if (money < parseFloat($(controles().value).val())) {
                $(controles().valueValid).text("Ainda falta R$" + ((money - parseFloat($(controles().value).val())) * -1).toFixed(2));
            }
            else {
                btnSubmit.click();
            }
        }

    }

    return {
        montarTabela: montarTabela,
        getModal: getModal,
        validSubmit: validSubmit
    }
}