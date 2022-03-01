FillDatatable();
$('#dvTable').hide();

const operationTypes = [
    { name: 'add', title: 'Toplama', value: 1, symbol: '+' },
    { name: 'subtract', title: 'Çıkarma', value: 2, symbol: '-' },
    { name: 'divide', value: 3, title: 'Bölme', symbol: '/' },
    { name: 'multiply', value: 4, title: 'Çarpma', symbol: '*' },
]

$('.btn-calculate').on("click", function () {

    const btnSymbol = $(this).attr('data-operation-symbol');
    const operationType = operationTypes.find(x => x.symbol === btnSymbol);

    $.post("/Calculator/Calculate", {
        number1: $('#txtNumber1').val(),
        number2: $('#txtNumber2').val(),
        operationType: operationType.value
    }, function (data, status) {
        $('#dvTable').show();

        if (data.Status) {

            var table = $('#tbResult tbody');

            table.empty();
            table.append($('<tr><td class="text-center" id="number1">' + $('#txtNumber1').val() + '</td>' +
                '<td class="text-center" id="number2">' + $('#txtNumber2').val() + '</td>' +
                '<td class="text-center" id="operationType">' + operationType.title + '</td>' +
                '<td class="text-center" id="outcome">' + data.ReturnData + '</td>' +
                '<td><button class="btn btn-sm btn-success" id="btnSave">Save</button></td></tr>'));

            $('#btnSave').off('click');
            $('#btnSave').on("click", function () {
                let number1 = document.getElementById("tbResult").rows[1].cells.item(0).innerHTML;
                let number2 = document.getElementById("tbResult").rows[1].cells.item(1).innerHTML;
                let outcome = document.getElementById("tbResult").rows[1].cells.item(3).innerHTML;

                $.post('/Calculator/Save', { number1: number1, number2: number2, operationType: operationType.value, outcome: outcome },
                    function (data, status) {
                        if (data.Status) {
                            FillDatatable();
                            $('#dvTable').hide();
                            $('#txtNumber1').val("");
                            $('#txtNumber2').val("");
                        } else {
                            alert(data.Message);
                            console.error(data.Message);
                        }
                    })
            })
        } else {
            alert(data.Message);
            console.error(data.Message);
        }
    })
});


function FillDatatable() {
    $.get("/Calculator/GetAll", function (data, status) {
        $('#tbCalculators').dataTable().fnDestroy();
        $('#tbCalculators').dataTable({
            paging: false,
            searching: false,
            ordering: false,
            dom: '<"row"<"col-lg-6"l><"col-lg-6"f>><"table-responsive"t>p',
            data: data,
            columns: [

                {
                    "data": "Number1",
                    "render": function (data, type, full, meta) {
                        return full.Number1
                    }
                },
                {
                    "data": "Number2",
                    "render": function (data, type, full, meta) {
                        return full.Number2
                    }
                },
                {
                    "data": "OperationType",
                    "render": function (data, type, full, meta) {
                        return full.OperationTypeDisplay
                    }
                },
                {
                    "data": "Outcome",
                    "render": function (data, type, full, meta) {
                        return full.Outcome
                    }
                }

            ],
            columnDefs: [
                {
                    "targets": 1,
                    "className": "text-center",
                }
            ],

        });
    })

}