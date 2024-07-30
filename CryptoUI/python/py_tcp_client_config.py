import g

def setup(add_tcp_client_config):
    g.log("py_tcp_client_config")
    add_tcp_client_config(6, '43.206.246.165', 50200, 1) # trading engine
    add_tcp_client_config(4, '43.206.246.165', 6666, 1) # param server