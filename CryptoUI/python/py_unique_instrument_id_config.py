import g

def setup(add_unique_instrument_id_config):
    g.log("py_unique_instrument_id_config")
    # instrument_id, unique_instrument_id
    for i in range(1,100):
        add_unique_instrument_id_config(i, i)
