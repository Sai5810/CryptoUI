import g

def setup(add_exchange_definition_config):
    g.log("py_exchange_definition_config")
    # exchange_id, exchange_name, family_name, letter_code
    add_exchange_definition_config(1, "Binance", "Binance", "B")
