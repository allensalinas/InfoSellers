var rolesJson;
var commissionTypesJson;
window.addEventListener('load', function(){
    loadCommissionTypes();
    loadRoles();
    loadSellers();

    document.getElementById('btnAddSeller').addEventListener('click', function(){
        openCreateDialog();
    });

    document.getElementById('btnSave').addEventListener('click',function(){
        saveEditing();
    });
});

var baseURL = 'http://localhost:60255/api/';

function loadSellers(){
    let table = document.getElementById('table-body');
    table.innerHTML='';
    console.log('loading selllers');
    fetch(baseURL + 'sellers', {mode: 'cors'}).then(function(response){
      return response.json();  
    }).then(function(jsonData){
        // alert(jsonData);
        for (let index = 0; index < jsonData.length; index++) {
            const element = jsonData[index];
            table.appendChild(getRow(element));
        }
    }).catch(function(msg){
        alert(msg);
    })
}

function loadRoles(){
    fetch(baseURL + 'roles', {mode: 'cors'}).then(function(response){
        return response.json();  
      }).then(function(jsonData){
          rolesJson = jsonData;
          let select = document.getElementById('listRole');
          select.options[select.options.length] = new Option('', 0);
          for (let index = 0; index < jsonData.length; index++) {
                select.options[select.options.length] = new Option(jsonData[index].RolName, jsonData[index].ID);
          }
      }).catch(function(msg){
          alert(msg);
      })
}

function loadCommissionTypes(){
    fetch(baseURL + 'commissiontypes', {mode: 'cors'}).then(function(response){
        return response.json();  
      }).then(function(jsonData){
          commissionTypesJson = jsonData;
      }).catch(function(msg){
          alert(msg);
      })
}

function getRow(seller){
    let row = document.createElement('tr');
    row.appendChild(getTd(seller.ID));
    row.appendChild(getTd(seller.Nit));
    row.appendChild(getTd(seller.FullName));
    row.appendChild(getTd(seller.Phone));
    row.appendChild(getTd(seller.SellerAddress));
    row.appendChild(getTd(seller.PenaltyPercentage));
    row.appendChild(getTd(seller.CurrentCommission));

    let rol = rolesJson.filter(rol=> rol.ID===seller.RolID);
    row.appendChild(getTd(rol[0].RolName));
    row.appendChild(getTd(seller.Active));

    let editColumn = document.createElement('button');
    editColumn.classList = 'btn btn-info';
    editColumn.innerText = 'Edit';
    editColumn.onclick = function(){
        console.log('click');
        openEditDialog(seller);
    };

    let deleteColumn = document.createElement('button');
    deleteColumn.classList = 'btn btn-danger';
    deleteColumn.innerText = 'Delete';
    deleteColumn.onclick = function(){
        deleteSeller(seller.ID);
    };

    row.appendChild(getCommand(editColumn));
    row.appendChild(getCommand(deleteColumn));

    return row;
}

function getTd(content){
    let td = document.createElement('td');
    td.innerText = content;
    return td;
}

function getCommand(command){
    let td = document.createElement('td');
    td.appendChild(command);
    return td;
}

function openCreateDialog(){
    document.getElementById('hdID').value = '';

    document.getElementById('txtNit').value = '';
    document.getElementById('txtFullName').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtAddress').value = '';
    document.getElementById('listRole').value = '';
    document.getElementById('txtPenaltyPercentage').value = '';
    document.getElementById('chkActive').checked = true;

    $('#editingModal').modal('show');
}

function openEditDialog(seller){
    document.getElementById('hdID').value = seller.ID;
    document.getElementById('txtNit').value = seller.Nit;
    document.getElementById('txtFullName').value = seller.FullName;
    document.getElementById('txtPhone').value = seller.Phone;
    document.getElementById('txtAddress').value = seller.SellerAddress;
    document.getElementById('listRole').value = seller.RolID;
    document.getElementById('txtPenaltyPercentage').value = seller.PenaltyPercentage;
    document.getElementById('chkActive').checked = seller.Active;
    
    // row.appendChild(getTd(seller.ID));
    // row.appendChild(getTd(seller.Nit));
    // row.appendChild(getTd(seller.FullName));
    // row.appendChild(getTd(seller.Phone));
    // row.appendChild(getTd(seller.SellerAddress));
    // row.appendChild(getTd(seller.PenaltyPercentage));
    // row.appendChild(getTd(seller.CurrentCommission));

// txtNit
// txtFullName
// txtPhone
// txtAddress
// listRole
// txtPenaltyPercentage
// chkActive

    $('#editingModal').modal('show');
}

function saveEditing(){
    let model = getModel();
    if (document.getElementById('hdID').value==='') //Creating new seller
    {
        var options = {mode: 'cors', method: 'POST', body: JSON.stringify(model), headers:{
            'Content-Type': 'application/json'
          }};
        fetch(baseURL + 'sellers',  options).then(function(response){
            if(response.ok)
            {
                $('#editingModal').modal('hide');
                loadSellers();
            }else{
                alert('Invalid response');
            }
        }).catch(function(error){
            alert(error);
        });
    }else{ //Editing existing one
        var options = {mode: 'cors', method: 'PUT', body: JSON.stringify(model), headers:{
            'Content-Type': 'application/json'
          }};
        fetch(baseURL + 'sellers/' + model.ID,  options).then(function(response){
            if(response.ok)
            {
                $('#editingModal').modal('hide');
                loadSellers();
            }else{
                alert('Invalid response');
            }
        }).catch(function(error){
            alert(error);
        });
    }
}

function deleteSeller(id){
    if (window.confirm('Are you sure you want to delete the selected seller?')) {
        var options = {mode: 'cors', method: 'DELETE'};
        fetch(baseURL + 'sellers/' + id,  options).then(function(response){
            if(response.ok)
            {
                loadSellers();
            }else{
                alert('Invalid response');
            }
        }).catch(function(error){
            alert(error);
        });
    }
}

function getModel(){
    let seller = {
        ID: document.getElementById('hdID').value,
        Nit: document.getElementById('txtNit').value,
        FullName: document.getElementById('txtFullName').value,
        Phone: document.getElementById('txtPhone').value,
        SellerAddress: document.getElementById('txtAddress').value,
        RolID: document.getElementById('listRole').value,
        PenaltyPercentage: document.getElementById('txtPenaltyPercentage').value,
        Active: document.getElementById('chkActive').checked
    };
    return seller;
}