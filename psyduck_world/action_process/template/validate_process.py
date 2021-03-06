import core.db
from action_process.template import validate_procedure
import datetime

procedures = []
_last_check_time = datetime.datetime.now()


def process_request():
    act = core.db.act_get('validate', 'request')
    if act is None:
        return
    core.db.act_set_state(act['id'], 'process', act['result'])
    procedures.append(validate_procedure.ValidateProcedure(act))


def procedure_update():
    for p in procedures:
        if p.over:
            procedures.remove(p)
            continue
        p.update()


def update():
    process_request()
    procedure_update()


def stop():
    for p in procedures:
        p.stop()
    procedures.clear()
