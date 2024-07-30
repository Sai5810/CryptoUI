import g

def setup(add_instrument_id_symbol_config):
    g.log("py_instrument_id_config")
    # instrument_id, symbol
    add_instrument_id_symbol_config(1, "BTCUSDT")
    add_instrument_id_symbol_config(2, "ETHUSDT")
    add_instrument_id_symbol_config(3, "BUSDUSDT")
    add_instrument_id_symbol_config(4, "BNBUSDT")
    add_instrument_id_symbol_config(5, "XRPUSDT")
    add_instrument_id_symbol_config(6, "USDCUSDT")
    add_instrument_id_symbol_config(7, "SOLUSDT")
    add_instrument_id_symbol_config(8, "ADAUSDT")
    add_instrument_id_symbol_config(9, "DOGEUSDT")
