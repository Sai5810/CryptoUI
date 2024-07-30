import g

def setup(add_manual_order_client_config):
    g.log("py_manual_order_client_config")
    # id, tcp_client_id
    add_manual_order_client_config(1, 6, 50000) # 50200