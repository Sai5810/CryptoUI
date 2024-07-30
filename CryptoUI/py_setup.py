import sys
sys.path.insert(0, str(rootpath)+"/python")
import g
import py_exchange_definition_config
import py_manual_order_client_config
import py_param_client_config
import py_tcp_client_config
import py_unique_instrument_id_config
import py_instrument_id_config


def initialize():
    log("---- starting python setup ----")
    g.init(rootpath,log,resolve_ip,splash_log)
    splash_log("starting py_exchange_definition_config")
    py_exchange_definition_config.setup(add_exchange_definition_config)
    splash_log("starting py_param_client_config")
    py_param_client_config.setup(add_param_client_config)
    splash_log("starting py_manual_order_client_config")
    py_manual_order_client_config.setup(add_manual_order_client_config)
    splash_log("starting py_tcp_client_config")
    py_tcp_client_config.setup(add_tcp_client_config)
    splash_log("starting py_unique_instrument_id_config")
    py_unique_instrument_id_config.setup(add_unique_instrument_id_config)
    splash_log("starting py_instrument_id_config")
    py_instrument_id_config.setup(add_instrument_id_symbol_config)

    return 42
