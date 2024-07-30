import g

def setup(add_nic_config):
    g.log("py_nic_config")
    # id,host_id,ip,mac
    add_nic_config(1, 1, "", "")