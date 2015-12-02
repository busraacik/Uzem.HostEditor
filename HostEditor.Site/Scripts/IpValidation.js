function ipv4checker(input) {
    //confirm cidr is valid network
    var cidr = input.split('/');
    var base = cidr[0];
    var bits = cidr[1];
    var ip = base.split('.');
    var i = (ip[0] << 24 | ip[1] << 16 | ip[2] << 8 | ip[3]);
    var mask = bits == 0 ? 0 : ((1 << (32 - bits)) - 1) ^ 0xFFFFFFFF;
    var network = i & mask;

    if (i == network) { return true; }
    else { return false; }
}

//custom vlidation rule - check IPv4
$.validator.addMethod("checkcidr",
    function (value, element, param) {
        return ipv4checker(value);
    });

//wire up the unobtrusive validation
$.validator.unobtrusive.adapters.add
    ("checkcidr", function (options) {
        options.rules["checkcidr"] = true;
        options.messages["checkcidr"] = options.message;
    });