import os

def init(rootpath_, log_, resolve_ip_, splash_log_):
    global rootpath
    rootpath = str(rootpath_)
    global log
    log = log_
    global resolve_ip
    resolve_ip = resolve_ip_
    global drive
    drive, _ = os.path.splitdrive(rootpath)
    global refpath
    refpath = drive+'/refdata/'
    global log_splash
    log_splash = splash_log_

def get_reference_data_dir():
    return "C:/refdata/"