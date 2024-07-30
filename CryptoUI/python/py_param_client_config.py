import g

def setup(add_param_client_config):
    g.log("py_param_client_config")
    # id, tcp_client_id
    add_param_client_config(1, 4) # 50028