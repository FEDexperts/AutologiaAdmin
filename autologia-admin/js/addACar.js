$(document).ready(function ()
{
    var mainType = $('#ddMainType input:checked');
    if (mainType) {
        $('.type1,.type2,.type3').hide();

        var mainTypeValue = mainType.val();
        $('.type' + mainTypeValue).show();

        switch (mainTypeValue) {
            case '1':
                $('.subType6').hide();
                $('.subType73').show();
                break;
            case '2':
                $('.subType6').hide();
                $('.subType73').show();
                break;
            case '3':
                break;
        }
    }

    $('#ddSubType').click(function ()
    {
        var mainType = $('#ddMainType input:checked');
        if (mainType && mainType.val() === '3') {
            $('.subType6,.subType72,.subType73').hide();

            var subType = $('#ddSubType input:checked');
            $('.subType' + subType.val()).show();
        }
    })
});